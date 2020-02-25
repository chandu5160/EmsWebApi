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
        public async Task<IActionResult> PostTaskTime([FromBody] TaskTimeModel taskTime)
        {
            if (taskTime == null)
            {
                return BadRequest();
            }
            taskTime.Date = DateTime.Now.Date;
            var newTaskTime = await this._taskTimeUsecase.AddTaskTime(taskTime);
            return Created("created new task-time", newTaskTime);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllTaskTimesByEmpId(int id)
        {
            var taskListByEmpId = await this._taskTimeUsecase.GetAllTaskTimesByEmpId(id);
            if (taskListByEmpId == null)
            {
                return NotFound();
            }
            return Ok(taskListByEmpId);
        }
    }
}
