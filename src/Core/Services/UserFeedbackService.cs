﻿using Core.Common.Class;
using Core.Common.Enums;
using Core.DTOs.Users;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories;
using Core.Repositories.Parameters;

namespace Core.Services;

public class UserFeedbackService
{
    private readonly IUserFeedbackRepository _userFeedbackRepository;
    private readonly IUserRepository _userRepository;

    public UserFeedbackService(
        IUserFeedbackRepository userFeedbackRepository, 
        IUserRepository userRepository)
    {
        _userFeedbackRepository = userFeedbackRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserFeedbackShort>> SearchAsync(
        string? userNameOrNovelName = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _userFeedbackRepository.SearchAsync(userNameOrNovelName ?? string.Empty, pagination, isDescending);

        return entities.Select(UserFeedbackMapper.ToShortForm);
    }

    public async Task<IEnumerable<UserFeedback>> GetNovelByStatus(
        CurrentStatus status,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _userFeedbackRepository.GetFeedbackByStatusAsync(status, pagination);
    }

    public async Task<UserFeedback?> GetAsync(string id)
    {
        return await _userFeedbackRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(UserFeedbackCreate create)
    {
        var feedback = UserFeedbackMapper.ToEntity(create);
        feedback.Status = Common.Enums.CurrentStatus.Awaiting_Approval;
        feedback.DateCreated = DateTime.Now;
        await _userFeedbackRepository.CreateAsync(feedback);
        return feedback.Id!;
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _userFeedbackRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

}
