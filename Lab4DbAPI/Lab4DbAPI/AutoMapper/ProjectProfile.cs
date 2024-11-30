using AutoMapper;
using Lab4DbAPI.Models;
using Lab4DbAPI.Models.DTO;

namespace Lab4DbAPI.AutoMapper
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<ProjectCreateDTO, ProjectDTO>();
            CreateMap<ProjectDTO, ProjectCreateDTO>();
        }
    }
}
