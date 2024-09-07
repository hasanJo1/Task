using AppService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDto);
        Task<bool> AssignEmployeesToProjectsAsync(EmployeeDTO dto);
    }
}
