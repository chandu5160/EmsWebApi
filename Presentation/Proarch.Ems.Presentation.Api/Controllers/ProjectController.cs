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
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectUsecase _projectUsecase;

        public ProjectController(IProjectUsecase projectUsecase)
        {
            this._projectUsecase = projectUsecase;
        }

        [HttpPost]
        public async Task<ProjectModel> PostProject([FromBody]ProjectModel project)
        {
            return await this._projectUsecase.AddProjectAsync(project);
        }

        [HttpGet]
        public async Task<List<ProjectModel>> GetAllProjects()
        {
            return await this._projectUsecase.GetAllProjectsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ProjectModel> GetProjectById(int id)
        {
            return await this._projectUsecase.GetProjectById(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await this._projectUsecase.DeleteProject(id).ConfigureAwait(false);

            return this.Ok();
        }
    }
}
