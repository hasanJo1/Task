using AppService.Dtos;
using AppService.Interfaces;
using AppService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            var employees = await _projectService.GetAllProjectsAsync();
            return Ok(employees);
        }
        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> AddProject(ProjectDTO projectDto)
        {
            var project = await _projectService.AddProjectAsync(projectDto);
            return CreatedAtAction(nameof(AddProject), new { id = project.Id }, project);
        }
    }
}
