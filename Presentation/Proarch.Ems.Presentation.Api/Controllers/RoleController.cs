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
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleUsecase _roleUsecase;

        public RoleController(IRoleUsecase roleUsecase)
        {
            this._roleUsecase = roleUsecase;
        }

        [HttpPost]
        public async Task<RoleModel> PostRole([FromBody]RoleModel role)
        {
            return await this._roleUsecase.AddRoleAsync(role).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<List<RoleModel>> GetAllRoles()
        {
            return await this._roleUsecase.GetAllRolesAsync();
        }

        [HttpGet("{id}")]
        public async Task<RoleModel> GetRoleById(int id)
        {
            return await this._roleUsecase.GetRoleById(id);
        }
    }
}