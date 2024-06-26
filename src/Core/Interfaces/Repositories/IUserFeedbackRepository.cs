﻿using Core.Common.Enums;
using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;

public interface IUserFeedbackRepository : IRepository<UserFeedback>
{
    Task<List<UserFeedback>> SearchAsync(
        string userName,
        PaginationParameters pagination,
        bool isDescending);
    Task<IEnumerable<UserFeedback>> GetFeedbackByStatusAsync(
        CurrentStatus? status,
        PaginationParameters pagination);
}
