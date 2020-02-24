using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.UseCases
{
    internal class RoleUsecase : IRoleUsecase
    {
        private IRoleRepository _roleRepository;

        public RoleUsecase(IRoleRepository roleRepository)
        {
          this._roleRepository = roleRepository;
        }
        Task<RoleModel> IRoleUsecase.AddRoleAsync(RoleModel role)
        {
            return this._roleRepository.AddRoleAsync(role);
            throw new NotImplementedException();
        }

        Task<List<RoleModel>> IRoleUsecase.GetAllRoleAsync()
        {
            return this._roleRepository.GetAllRoleAsync();
        }

        Task<RoleModel> IRoleUsecase.GetRoleById(int id)
        {
            return this._roleRepository.GetRoleById(id);
        }
    }
}
