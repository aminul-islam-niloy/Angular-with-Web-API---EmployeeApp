using EmployeeApp.Models;
using EmployeeApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _emp;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _emp = employeeRepository;
        }

        // GET: api/EmployeeList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> EmployeeList()
        {
            var employees = await _emp.GetAllEmployees();
            return Ok(employees);
        }

        // POST: api/SaveEmployee
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            await _emp.SaveEmployee(employee);
            return Ok(employee);
        }


        // PUT: api/Employee/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> updateEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest("Employee ID mismatch.");
            }

            var updateSuccessful = await _emp.updateEmployee(employee);
            if (!updateSuccessful)
            {
                return NotFound("Employee not found.");
            }

            return Ok(employee); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteEmployee(int id)
        {
            var deleteSuccessful = await _emp.DeleteEmployee(id);
            if (!deleteSuccessful)
            {
                return NotFound("Employee not found.");
            }

            return Ok(); 
        }
    }
}
