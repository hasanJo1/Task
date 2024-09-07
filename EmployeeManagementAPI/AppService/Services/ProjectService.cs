using AppService.Dtos;
using AppService.Interfaces;
using Data.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AppService.Services
{
    public class ProjectService : IProjectService
    {
        private readonly EmployeeManagementContext _context;
        private readonly IMapper _mapper;

        public ProjectService(EmployeeManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDto)
        {
            //var project = _mapper.Map<Project>(projectDto);

            Project project = new Project();

            project.Id=projectDto.Id;
            project.Name=projectDto.Name;
            project.Description=projectDto.Description;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            var project = await _context.Projects.ToListAsync();
            List<ProjectDTO> result = new List<ProjectDTO>();
            foreach (var item in project)
            {
                result.Add(new ProjectDTO { 
                 Id=item.Id,
                  Description=item.Description,
                   Name=item.Name
                
                });

            }
            return result;
        }
    }
}
