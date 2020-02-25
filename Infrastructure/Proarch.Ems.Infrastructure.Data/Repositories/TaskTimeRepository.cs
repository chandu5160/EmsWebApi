using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Contracts.Dto;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Repositories
{
    internal class TaskTimeRepository : ITaskTimeRepository
    {
        private readonly EmsDbContext _context;
        private readonly IMapper _mapper;

        public TaskTimeRepository(EmsDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
     async   Task<TaskTimeModel> ITaskTimeRepository.AddTaskTime(TaskTimeModel taskTime)
        {
            var taskTimeEntity = this._mapper.Map<TaskTimeEntity>(taskTime);

            this._context.TaskTime.Add(taskTimeEntity);

            await this._context.SaveChangesAsync();

            return this._mapper.Map<TaskTimeModel>(taskTimeEntity);
        }

       async Task<List<TaskTimeDto>> ITaskTimeRepository.GetAllTaskTimesByEmpId(int id)
        {
            var date1 = DateTime.Now.AddDays(-10).Date;
            var date2 = DateTime.Now.Date;


            var result = await this._context.TaskTime.Join(
                _context.UserStorie,
                taskTime => taskTime.UserStoryId,
                userStory => userStory.Id,
                (taskTime, userStory) => new
                {
                    Id = taskTime.Id,
                    Hours=taskTime.Hours,
                    Remarks=taskTime.Remarks,
                    userStory = userStory
                    
                }
                ).ToListAsync();

            return  this._mapper.Map<List<TaskTimeDto>>(result);

        }
    }
}
