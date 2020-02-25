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
        public async Task<IActionResult> PostUserStory([FromBody] UserStoryModel userStoryModel)
        {
            if (userStoryModel == null)
            {
                return BadRequest();
            }
            var newUserStory = await this._userStoryUsecase.AddUserStory(userStoryModel);
            return Created("Creadted new user story", newUserStory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllUserStoriesByEmpId(int id)
        {
            var userStoryLisByEmpId = await this._userStoryUsecase.GetAllUserStoriesByEmpId(id);
            if (userStoryLisByEmpId == null)
            {
                return NotFound();
            }
            return Ok(userStoryLisByEmpId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserStory(int id, [FromBody] UserStoryModel userStoryModel)
        {
            if (id != userStoryModel.Id)
            {
                return BadRequest();
            }
            var updatedUserStory = await this._userStoryUsecase.UpdateUserStory(id, userStoryModel);
            return Ok(updatedUserStory);
        }

        [HttpPut("close-user-story/{id}")]
        public async Task<IActionResult> CloseUserStory(int id, [FromBody] UserStoryModel userStoryModel)
        {
            if (id != userStoryModel.Id)
            {
                return BadRequest();
            }
            var updatedUserStory = await this._userStoryUsecase.CloseUserStory(id, userStoryModel);
            return Ok(updatedUserStory);
        }
    }

}