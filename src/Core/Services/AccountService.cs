using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;
using Core.DTOs.Accounts;
using Core.Entities;
using Core.Common.Helpers;
using Core.Common.Class;

namespace Core.Services;

public class AccountService
{
    #region Service Declaration

    private readonly IAccountRepository _accountRepository;
    private readonly TokenCacheService _tokenCacheService;
    private readonly IWalletRepository _walletRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IUserRepository _userRepository;
    private readonly JwtService _jwtService;
    private readonly Validation _validation;

    public AccountService(
        IAccountRepository accountRepository,
        TokenCacheService tokenCacheService, 
        IWalletRepository walletRepository,
        IAuthorRepository authorRepository,
        IUserRepository userRepository,
        JwtService jwtService,
        Validation validation)
    {
        _accountRepository = accountRepository;
        _tokenCacheService = tokenCacheService;
        _walletRepository = walletRepository;
        _authorRepository = authorRepository;
        _userRepository = userRepository;
        _jwtService = jwtService;
        _validation = validation;
    }

    #endregion

    #region Account Query

    public async Task<IEnumerable<AccountShort>> SearchAsync(
        string? emailOrName = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _accountRepository.SearchAsync(emailOrName ?? string.Empty, pagination, isDescending);

        return entities.Select(AccountMapper.ToShortForm);
    }

    public async Task<Account?> GetAsync(string id)
    {
        return await _accountRepository.GetAsync(id);
    }

    public async Task<Account?> GetAccountByEmail(string email)
    {
        return await _accountRepository.GetByEmailAsync(email);
    }

    public async Task<string> RegisterAsync(RegisterAccount register)
    {
        #region Validation

        // Kiểm tra xem Email đã được đăng ký chưa
        var existingAccount = await _accountRepository.GetByEmailAsync(register.Email);
        if (existingAccount != null)
        {
            throw new InvalidOperationException("Email already exists");
        }

        // Kiểm tra hợp lệ của dữ liệu đầu vào
        if (!_validation.IsValidEmail(register.Email))
        {
            throw new ArgumentException("Email is not valid");
        }
        if (!_validation.IsValidPassword(register.Password))
        {
            throw new ArgumentException("Password is not valid");
        }

        #endregion 

        var account = AccountMapper.ToEntity(register);
        account.Password = _validation.HashPassword(register.Password);
        account.DateCreated = DateTime.UtcNow;
        await _accountRepository.CreateAsync(account);

        #region Created User

        //Nếu RoleType là User, tạo User và Wallet
        if (register.Role == Common.Enums.RoleType.User)
        {
            var user = new User
            {
                Email = register.Email,
                Name = register.Name,
                DateCreated = DateTime.Now
            };
            await _userRepository.CreateAsync(user);

            var wallet = new Wallet
            {
                Balance = 0,
                DateCreated = DateTime.Now,
            };
            await _walletRepository.CreateAsync(wallet);

            // Kiểm tra thông tin Id của User và Wallet

            var userId = await _userRepository.GetAsync(user.Id!);
            if(userId is null)
            {
                throw new KeyNotFoundException();
            }
            var userInfo = new UserInfo
            {
                UserId = user.Id!,
                UserName = user.Name
            };

            var walletId = await _walletRepository.GetAsync(wallet.Id!);
            if (walletId is null)
            {
                throw new KeyNotFoundException();
            }
            var walletInfo = new WalletInfo
            {
                WalletId = wallet.Id!,
                Balance = wallet.Balance
            };

            // Cập nhật UserId và WalletId vào tài khoản
            account.UserId = userId.Id;
            account.User = userInfo;
            account.WalletId = walletId.Id;
            account.Wallet = walletInfo;
            await _accountRepository.UpdateAsync(account);
        }

        #endregion

        #region Created Author

        //Nếu RoleType là Author, tạo Author và Wallet
        if (register.Role == Common.Enums.RoleType.Author)
        {

            var author = new Author
            {
                Email = register.Email,
                Name = register.Name,
                DateCreated = DateTime.Now
            };
            await _authorRepository.CreateAsync(author);

            var wallet = new Wallet
            {
                Balance = 0,
                DateCreated = DateTime.Now
            };
            await _walletRepository.CreateAsync(wallet);

            // Kiểm tra thông tin Id của Author và Wallet

            var authorId = await _authorRepository.GetAsync(author.Id!);
            if (authorId is null)
            {
                throw new KeyNotFoundException();
            }
            var authorInfo = new AuthorInfo
            {
                AuthorId = authorId.Id!,
                AuthorName = authorId.Name
            };

            var walletId = await _walletRepository.GetAsync(wallet.Id!);
            if (walletId is null)
            {
                throw new KeyNotFoundException();
            }
            var walletInfo = new WalletInfo
            {
                WalletId = walletId.Id!,
                Balance = walletId.Balance
            };

            // Cập nhật UserId và WalletId vào tài khoản
            account.AuthorId = authorId.Id;
            account.Author = authorInfo;
            account.WalletId = walletId.Id;
            account.Wallet = walletInfo;
            await _accountRepository.UpdateAsync(account);
        }

        #endregion

        return account.Id!;
    }

    public async Task<string?> LoginAsync(LoginAccount login)
    {
        // Kiểm tra email và mật khẩu có đúng dữ liệu mẫu
        if (!_validation.IsValidEmail(login.Email) || !_validation.IsValidPassword(login.Password))
        {
            throw new InvalidOperationException("Invalid email or password");
        }

        // Kiểm tra email và mật khẩu có đúng không
        var existingAccount = await _accountRepository.GetByEmailAsync(login.Email);
        if (existingAccount == null || !_validation.VerifyPassword(existingAccount.Password, login.Password))
        {
            throw new InvalidOperationException("Email or password is incorrect");
        }

        // Tạo JWT token và lưu token vào cache
        // Giả sử người dùng muốn nhớ đăng nhập
        var token = _jwtService.GenerateToken(existingAccount.Id!,existingAccount.Role.Value, true);
        // Lưu token vào cache
        _tokenCacheService.StoreToken(existingAccount.Id!, token, true);

        return token;
    }

    public async Task ChangePasswordAsync(string id, string token, ChangePasswordAccount changePassword)
    {
        // Kiểm tra xác thực người dùng, ví dụ: sử dụng token
        var accountId = _jwtService.GetAccountIdFromToken(token);
        var isValid = _jwtService.VerifyToken(token, out accountId);
        if (!isValid || accountId != id)
        {
            throw new InvalidOperationException("Invalid token or account ID");
        }

        // Kiểm tra mật khẩu cũ có đúng không
        var existingAccount = await _accountRepository.GetAsync(id);
        if (existingAccount == null) 
        {
            throw new KeyNotFoundException("Account not found");
        }

        if (!_validation.VerifyPassword(existingAccount.Password, changePassword.OldPassword))
        {
            throw new InvalidOperationException("Old password is incorrect");
        }

        // Kiểm tra và xác thực mật khẩu mới
        if (!_validation.IsValidPassword(changePassword.NewPassword))
        {
            throw new ArgumentException("New password is not valid");
        }

        if(changePassword.NewPassword != changePassword.ConfirmPassword)
        {
            throw new ArgumentException("Passwords do not match");
        }

        // Lưu mật khẩu mới (đã được mã hóa)
        existingAccount.Password = _validation.HashPassword(changePassword.NewPassword);

        // Lưu thay đổi vào CSDL
        await _accountRepository.UpdateAsync(existingAccount);
    }

    public async Task DeleteAsync(string id)
    {
        var entity = await _accountRepository.GetAsync(id);
        if(entity != null)
        {
            await _accountRepository.DeleteAsync(id);

            if(entity is Account)
            {
                var account = entity as Account;
                if(account.Role == Common.Enums.RoleType.User)
                {
                    await _userRepository.DeleteAsync(account.UserId!);
                    await _walletRepository.DeleteAsync(account.WalletId!);
                }
                else if(account.Role == Common.Enums.RoleType.Author)
                {
                    await _authorRepository.DeleteAsync(account.AuthorId!);
                    await _walletRepository.DeleteAsync(account.WalletId!);
                }
            }
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }

    #endregion
}
