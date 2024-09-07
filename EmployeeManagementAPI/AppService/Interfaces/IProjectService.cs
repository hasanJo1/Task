using AppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDto);
        Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync();
    }
}
