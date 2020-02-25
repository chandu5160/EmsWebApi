using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Application.Contracts.Dto;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.UseCases
{
    internal class TaskTimeUsecase : ITaskTimeUsecase
    {

        private readonly ITaskTimeRepository _taskTimeRepository;

        public TaskTimeUsecase(ITaskTimeRepository taskTimeRepository)
        {
            this._taskTimeRepository = taskTimeRepository;
        }

        Task<TaskTimeModel> ITaskTimeUsecase.AddTaskTime(TaskTimeModel taskTime)
        {
            taskTime.Date =taskTime.Date;
            return this._taskTimeRepository.AddTaskTime(taskTime);
        }

        Task<List<TaskTimeDto>> ITaskTimeUsecase.GetAllTaskTimesByEmpId(int id)
        {
            return this._taskTimeRepository.GetAllTaskTimesByEmpId(id);
        }
    }
}
