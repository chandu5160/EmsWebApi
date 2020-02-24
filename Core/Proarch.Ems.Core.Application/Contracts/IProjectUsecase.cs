using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Contracts
{
    public interface IProjectUsecase
    {
        Task<ProjectModel> AddProjectAsync(ProjectModel project);
        Task<List<ProjectModel>> GetAllProjectsAsync();
        Task<ProjectModel> GetProjectById(int id);
        Task DeleteProject(int id);
    }
}
