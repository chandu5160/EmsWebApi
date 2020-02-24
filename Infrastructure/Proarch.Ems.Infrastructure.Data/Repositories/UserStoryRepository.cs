using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    internal class UserStoryRepository : IUserStoryRepository
    {
        private readonly EmsDbContext _context;
        private readonly IMapper _mapper;

        public UserStoryRepository(EmsDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        async Task<UserStoryModel> IUserStoryRepository.AddUserStory(UserStoryModel userStoryModel)
        {
            var userStoryEntity = this._mapper.Map<UserStoryEntity>(userStoryModel);
            _context.UserStorie.Add(userStoryEntity);
            await _context.SaveChangesAsync();
            return this._mapper.Map<UserStoryModel>(userStoryEntity);
        }

        async Task<List<UserStoryModel>> IUserStoryRepository.GetAllUserStoriesByEmpId(int id)
        {
            var userStoriesList = await this._context.UserStorie
                .Where(x => x.Id == id)
                .ToListAsync();
            return this._mapper.Map<List<UserStoryModel>>(userStoriesList);
        }

        async Task<UserStoryModel> IUserStoryRepository.UpdateUserStory(int id, UserStoryModel userStoryModel)
        {
            var existingUserStory = await this._context
                                    .UserStorie
                                    .SingleOrDefaultAsync(x => x.Id == id)
                                    .ConfigureAwait(false);
            if (existingUserStory != null)
            {
                this._context.Entry(userStoryModel).State = EntityState.Modified;
                await this._context.SaveChangesAsync();
                return userStoryModel;
            }
            else
            {
                throw new System.NotImplementedException(); ;
            }
        }
    }
}



