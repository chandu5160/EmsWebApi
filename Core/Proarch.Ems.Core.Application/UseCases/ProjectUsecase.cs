using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.UseCases
{
    internal class ProjectUsecase : IProjectUsecase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectUsecase(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }
        Task<ProjectModel> IProjectUsecase.AddProjectAsync(ProjectModel project)
        {
            project.SetStatus(true);
            return this._projectRepository.AddProjectAsync(project);
        }

        Task IProjectUsecase.DeleteProject(int id)
        {
            return this._projectRepository.DeleteProject(id);
        }

        Task<List<ProjectModel>> IProjectUsecase.GetAllProjectsAsync()
        {
            return this._projectRepository.GetAllProjectsAsync();
        }

        Task<ProjectModel> IProjectUsecase.GetProjectById(int id)
        {
            return this._projectRepository.GetProjectById(id);
        }
    }
}
