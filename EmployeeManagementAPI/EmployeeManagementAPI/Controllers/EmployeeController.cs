using AppService.Dtos;
using AppService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee(EmployeeDTO employeeDto)
        {
            var employee = await _employeeService.AddEmployeeAsync(employeeDto);


            


            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpPost("assignEmployeesOnProjects")]
        public async Task<IActionResult> AssignEmployeesOnProjects(EmployeeDTO dto)
        {
            var success = await _employeeService.AssignEmployeesToProjectsAsync(dto);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
