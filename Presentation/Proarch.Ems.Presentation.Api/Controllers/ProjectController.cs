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
        public async Task<IActionResult> PostProject([FromBody]ProjectModel project)
        {
            if(project == null)
            {
                return BadRequest();
            }
            var newProject= await this._projectUsecase.AddProjectAsync(project);
            return Created("created new Project", newProject);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var allProjects = await this._projectUsecase.GetAllProjectsAsync());
            if (allProjects == null)
            {
                return NotFound();
            }

            return Ok(allProjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var projectById= await this._projectUsecase.GetProjectById(id);
            if (projectById == null)
            {
                return NotFound();
            }
            return Ok(projectById);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await this._projectUsecase.DeleteProject(id).ConfigureAwait(false);

            return this.Ok();
        }
    }
}
