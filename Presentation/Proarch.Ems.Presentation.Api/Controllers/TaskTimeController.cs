using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Application.Contracts.Dto;
using Proarch.Ems.Core.Domain.Models;

namespace Proarch.Ems.Presentation.Api.Controllers
{
    [Route("api/task-time")]
    [ApiController]
    public class TaskTimeController : ControllerBase
    {
        private readonly ITaskTimeUsecase _taskTimeUsecase;

        public TaskTimeController(ITaskTimeUsecase taskTimeUsecase)
        {
            this._taskTimeUsecase = taskTimeUsecase;
        }

        [HttpPost]
        public async Task<TaskTimeModel> PostTaskTime([FromBody] TaskTimeModel taskTime)
        {
            taskTime.Date = DateTime.Now.Date;
            return await this._taskTimeUsecase.AddTaskTime(taskTime);
        }

        [HttpGet("{id}")]
        public async Task<List<TaskTimeDto>> GetAllTaskTimesByEmpId(int id)
        {
            return await this._taskTimeUsecase.GetAllTaskTimesByEmpId(id);
        }
    }
}
