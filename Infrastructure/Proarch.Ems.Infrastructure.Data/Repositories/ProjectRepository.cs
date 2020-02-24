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
    internal class ProjectRepository : IProjectRepository
    {
        private readonly EmsDbContext _context;
        private readonly IMapper _mapper;

        public ProjectRepository(EmsDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        async Task<ProjectModel> IProjectRepository.AddProjectAsync(ProjectModel project)
        {
            var projectEntity = this._mapper.Map<ProjectEntity>(project);

            this._context.Project.Add(projectEntity);

            await this._context.SaveChangesAsync();

            return this._mapper.Map<ProjectModel>(projectEntity);
        }

        async Task<List<ProjectModel>> IProjectRepository.GetAllProjectsAsync()
        {
            var projectList = await this._context.Project.ToListAsync();
            return this._mapper.Map<List<ProjectModel>>(projectList);
        }

        async Task<ProjectModel> IProjectRepository.GetProjectById(int id)
        {
            var existingProject = await this._context
                                   .Project
                                   .SingleOrDefaultAsync(x => x.Id == id)
                                   .ConfigureAwait(false);
            return this._mapper.Map<ProjectModel>(existingProject);
        }

        async Task IProjectRepository.DeleteProject(int id)
        {
            var existingProject = await this._context
                                .Project
                                .SingleOrDefaultAsync(x => x.Id == id)
                                .ConfigureAwait(false);
            if (existingProject != null)
            {
                this._context.Project.Remove(existingProject);
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
