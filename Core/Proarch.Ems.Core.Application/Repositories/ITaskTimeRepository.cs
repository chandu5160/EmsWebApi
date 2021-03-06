﻿using Proarch.Ems.Core.Application.Contracts.Dto;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Repositories
{
    public interface ITaskTimeRepository
    {
        Task<TaskTimeModel> AddTaskTime(TaskTimeModel taskTime);
        Task<List<TaskTimeDto>> GetAllTaskTimesByEmpId(int id);
    }
}
