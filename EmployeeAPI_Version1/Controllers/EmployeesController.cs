using EmployeeAPI_Version1.Models;
using EmployeeAPI_Version1.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Runtime.InteropServices;

namespace EmployeeAPI_Version1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository EmployeeRepository)
        {
            _employeeRepository = EmployeeRepository;
        }

        // This indicates it will handle all the HTTP gets
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.Get();
        }

        [HttpGet("{EmployeeId}")]
        public async Task<Employee> GetEmployees(int EmployeeId)
        {
            return await _employeeRepository.Get(EmployeeId);
        }

        // This will handle all posts
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees([FromBody] Employee employee)
        {
            var newEmployee = await _employeeRepository.Create(employee);
            return CreatedAtAction(nameof(GetEmployees), new { EmployeeID = newEmployee.EmployeeId }, newEmployee);
        }

        [HttpPut]
        public async Task<ActionResult> PutEmployees(int EmployeeID, [FromBody] Employee employee)
        {
            if (EmployeeID != employee.EmployeeId)
            {
                return BadRequest();
            }
            await _employeeRepository.Update(employee);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int EmployeeId)
        {
            var employeeToDelete = await _employeeRepository.Get(EmployeeId);

            if (employeeToDelete == null)
            {
                return NotFound();
            }
            await _employeeRepository.Delete(employeeToDelete.EmployeeId);
            return NoContent();
        }
    }
}
