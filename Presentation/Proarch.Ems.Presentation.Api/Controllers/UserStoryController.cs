using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Domain.Models;

namespace Proarch.Ems.Presentation.Api.Controllers
{
    [Route("api/user-story")]
    [ApiController]
    public class UserStoryController : ControllerBase
    {
        private readonly IUserStoryUsecase _userStoryUsecase;

        public UserStoryController(IUserStoryUsecase userStoryUsecase)
        {
            this._userStoryUsecase = userStoryUsecase;
        }

        [HttpPost]
        public async Task<UserStoryModel> PostUserStory([FromBody] UserStoryModel userStoryModel)
        {
            return await this._userStoryUsecase.AddUserStory(userStoryModel);
        }

        [HttpGet("{id}")]
        public async Task<List<UserStoryModel>> GetAllUserStoriesByEmpId(int id)
        {
            return await this._userStoryUsecase.GetAllUserStoriesByEmpId(id);
        }

        [HttpPut("{id}")]
        public async Task<UserStoryModel> PutUserStory(int id, [FromBody] UserStoryModel userStoryModel)
        {
            return await this._userStoryUsecase.UpdateUserStory(id, userStoryModel);
        }

        [HttpPut("close-user-story/{id}")]
        public async Task<UserStoryModel> CloseUserStory(int id, [FromBody] UserStoryModel userStoryModel)
        {
            return await this._userStoryUsecase.CloseUserStory(id, userStoryModel);
        }
    }

}