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
        public async Task<IActionResult> PostRole([FromBody]RoleModel role)
        {
            if (role == null)
            {
                return BadRequest();
            }
            var newRole = await this._roleUsecase.AddRoleAsync(role).ConfigureAwait(false);
            return Created("created new role", newRole);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var allRoles =await this._roleUsecase.GetAllRolesAsync();
            if (allRoles == null)
            {
                return NotFound();
            }

            return Ok(allRoles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var roleById = await this._roleUsecase.GetRoleById(id);
            if (roleById == null)
            {
                return NotFound();
            }
            return Ok(roleById);
        }
    }
}