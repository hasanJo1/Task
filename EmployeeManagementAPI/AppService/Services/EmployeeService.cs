using AppService.Dtos;
using AppService.Interfaces;
using AutoMapper;
using Data;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeManagementContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(EmployeeManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.EmployeeProjects)
                .ThenInclude(ep => ep.Project)
                .ToListAsync();


            List<EmployeeDTO> employees1=new List<EmployeeDTO>();

            foreach (var employee in employees)
            {
                List<ProjectDTO> projects=new List<ProjectDTO>();
                foreach (var project in employee.EmployeeProjects)
                {
                    projects.Add(new ProjectDTO()
                    {

                        Id=project.Project.Id,
                         Name=project.Project.Name,
                          Description=project.Project.Description
                    });

                }
                employees1.Add(new EmployeeDTO()
                {
                    Name = employee.Name,
                    Id = employee.Id,
                    Position = employee.Position,
                    Projects=projects


                });
            }


            return employees1;
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeeProjects)
                .ThenInclude(ep => ep.Project)
                .FirstOrDefaultAsync(e => e.Id == id);

            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
            EmployeeDTO employee1 = new EmployeeDTO();
            employee1.Position = employee.Position;
            employee1.Name=employee.Name;
            employee1.Id=employee.Id;

            foreach(var p in employee.EmployeeProjects)
            {

                projectDTOs.Add(new ProjectDTO()
                {
                    Id=p.Project.Id,
                    Description=p.Project.Description,
                    Name=p.Project.Name,


                });

            }


            employee1.Projects=projectDTOs;

            return employee1;
        }

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDto)
        {
            //var employee = _mapper.Map<Employee>(employeeDto);

            Employee employee = new Employee();
            List<EmployeeProject> employeeProject = new List<EmployeeProject>();



            employee.Id=employeeDto.Id;
            employee.Name=employeeDto.Name;
            employee.Position=employeeDto.Position;


            foreach(var p in employeeDto.Projects)
            {
                EmployeeProject EmployeeProject = new EmployeeProject();
                EmployeeProject.ProjectId=p.Id;
                EmployeeProject.EmployeeId=employeeDto.Id;
                employeeProject.Add(EmployeeProject);

            }
            employee.EmployeeProjects=employeeProject;

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<bool> AssignEmployeesToProjectsAsync(AssignEmployeeToProjectDTO dto)
        {
            var employee = await _context.Employees
                .Include(e => e.EmployeeProjects)
                .FirstOrDefaultAsync(e => e.Id == dto.EmployeeId);

            if (employee == null) return false;

            employee.EmployeeProjects.Clear();

            foreach (var projectId in dto.ProjectIds)
            {
                employee.EmployeeProjects.Add(new EmployeeProject
                {
                    EmployeeId = dto.EmployeeId,
                    ProjectId = projectId
                });
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
