using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Repositories
{
    public interface IProjectRepository
    {
        Task<ProjectModel> AddProjectAsync(ProjectModel project);
        Task<List<ProjectModel>> GetAllProjectsAsync();
        Task<ProjectModel> GetProjectById(int id);
        Task DeleteProject(int id);
    }
}
