using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.UseCases
{
    internal class UserStoryUsecase : IUserStoryUsecase
    {

        private readonly IUserStoryRepository _userStoryRepository;

        public UserStoryUsecase(IUserStoryRepository userStoryRepository)
        {
            this._userStoryRepository = userStoryRepository;
        }
        Task<UserStoryModel> IUserStoryUsecase.AddUserStory(UserStoryModel userStoryModel)
        {
            if (userStoryModel.IsRecurring)
            {
                userStoryModel.AddHours(userStoryModel.DefaultHours);
            }
            userStoryModel.SetStatus(true);
            return this._userStoryRepository.AddUserStory(userStoryModel);
        }

        Task<UserStoryModel> IUserStoryUsecase.CloseUserStory(int id, UserStoryModel userStoryModel)
        {
            if (id == userStoryModel.Id)
            {
                userStoryModel.SetStatus(false);
                return this._userStoryRepository.UpdateUserStory(id, userStoryModel);
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }

        Task<List<UserStoryModel>> IUserStoryUsecase.GetAllUserStoriesByEmpId(int id)
        {
            return this._userStoryRepository.GetAllUserStoriesByEmpId(id);
        }

        Task<UserStoryModel> IUserStoryUsecase.UpdateUserStory(int id, UserStoryModel userStoryModel)
        {

            if (id == userStoryModel.Id)
            {
                return this._userStoryRepository.UpdateUserStory(id, userStoryModel);
            }
            else
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
