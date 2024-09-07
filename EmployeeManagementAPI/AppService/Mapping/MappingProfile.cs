// MappingProfile.cs
using AppService.Dtos;
using AutoMapper;
using Data.Model;
using System.Linq;

namespace AppService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Project, ProjectDTO>();
            CreateMap<AssignEmployeeToProjectDTO, EmployeeProject>();
        }
    }
}
