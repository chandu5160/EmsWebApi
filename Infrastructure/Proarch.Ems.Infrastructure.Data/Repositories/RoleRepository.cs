using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Repositories
{
    internal class RoleRepository : IRoleRepository

    {
        private readonly EmsDbContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(EmsDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

       async Task<RoleModel> IRoleRepository.AddRoleAsync(RoleModel role)
        {
            var roleEntity = _mapper.Map<RoleEntity>(role);
            _context.Role.Add(roleEntity);
            await this._context.SaveChangesAsync().ConfigureAwait(false);
            return this._mapper.Map<RoleModel>(roleEntity);
        }

       async Task<List<RoleModel>> IRoleRepository.GetAllRolesAsync()
        {
            var roleList = await this._context.Role.ToListAsync();
            return this._mapper.Map<List<RoleModel>>(roleList);
        }

       async Task<RoleModel> IRoleRepository.GetRoleById(int id)
        {
            var existingRole = await this._context
                                   .Role
                                   .SingleOrDefaultAsync(x => x.Id == id)
                                   .ConfigureAwait(false);
            return this._mapper.Map<RoleModel>(existingRole);
        }
    }
}
