using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;

public interface ICommentRepository : IRepository<Comment>
{
    Task<List<Comment>> SearchAsync(
        string userNameOrNovelName,
        PaginationParameters pagination,
        bool isDescending);
}
