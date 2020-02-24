using AutoMapper;
using Proarch.Ems.Core.Application.Contracts.Dto;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Infrastructure.Data.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ClientEntity, ClientModel>().ReverseMap();
            CreateMap<ProjectEntity, ProjectModel>().ReverseMap();
            CreateMap<UserStoryEntity, UserStoryModel>().ReverseMap();
            CreateMap<TaskTimeEntity, TaskTimeModel>().ReverseMap();
            CreateMap<TaskTimeEntity, TaskTimeDto>().ReverseMap();
        }

       
    }
}
