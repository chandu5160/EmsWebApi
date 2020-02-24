﻿using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Contracts
{
    public interface IUserStoryUsecase
    {
        Task<UserStoryModel> AddUserStory(UserStoryModel userStoryModel);
        Task<List<UserStoryModel>> GetAllUserStoriesByEmpId(int id);
        Task<UserStoryModel> UpdateUserStory(int id, UserStoryModel userStoryModel);
        Task<UserStoryModel> CloseUserStory(int id, UserStoryModel userStoryModel);
    }
}
