using Core.Common.Class;
using Core.DTOs.Comments;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories;
using Core.Repositories.Parameters;

namespace Core.Services;

public class CommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    private readonly INovelRepository _novelRepository;

    public CommentService(
        ICommentRepository commentRepository, 
        IUserRepository userRepository, 
        INovelRepository novelRepository)
    {
        _commentRepository = commentRepository;
        _userRepository = userRepository;
        _novelRepository = novelRepository;
    }

    public async Task<IEnumerable<CommentShort>> SearchAsync(
        string? userNameOrNovelName = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _commentRepository.SearchAsync(userNameOrNovelName ?? string.Empty, pagination, isDescending);

        return entities.Select(CommentMapper.ToShortForm);
    }

    public async Task<IEnumerable<Comment>> GetCommentsByNovelId(string novelId)
    {
        return await _commentRepository.GetByFieldAsync(c => c.NovelId == novelId);
    }

    public async Task<IEnumerable<Comment>> GetCommentByNovelIdAsync(
        string novelId,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _commentRepository.GetCommentByNovelIdAsync(novelId, pagination);
    }

    public async Task<uint> GetCountByNovelAsync(string novelId)
    {
        return await _commentRepository.GetCountByNovelAsync(novelId);
    }

    public async Task<uint> GetAllCountAsync()
    {
        return await _commentRepository.GetAllCountAsync();
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _commentRepository.GetAllAsync();
    }

    public async Task<Comment?> GetAsync(string id)
    {
        return await _commentRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(CommentCreate create)
    {
        var user = await _userRepository.GetAsync(create.UserId);
        if(user is null)
        {
            throw new KeyNotFoundException();
        }
        var novel = await _novelRepository.GetAsync(create.NovelId);
        if(novel is null)
        {
            throw new KeyNotFoundException();
        }

        var userInfo = new UserInfo
        {
            UserId = user.Id!,
            UserName = user.Name
        };
        var novelInfo = new NovelInfo
        {
            NovelId = novel.Id!,
            NovelName = novel.Name
        };

        var comment = CommentMapper.ToEntity(create);
        comment.User = userInfo;
        comment.Novel = novelInfo;
        comment.DateCreated = DateTime.Now;
        await _commentRepository.CreateAsync(comment);

        return comment.Id!;
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _commentRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

    public async Task DeleteCommentsByNovelIdAsync(string novelId)
    {
        await _commentRepository.DeleteByFieldAsync(c => c.NovelId == novelId);
    }
}
