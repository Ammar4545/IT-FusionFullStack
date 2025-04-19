using IT_Fusion_API.Models;
using IT_Fusion_API.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace IT_Fusion_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeFileService _employeeService;

        public EmployeesController(IEmployeeFileService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var emps = _employeeService.GetAll();
            return Ok(emps);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeService.GetById(id);
            return employee != null ? Ok(employee) : NotFound();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var existing = _employeeService.GetById(employee.Id);
            if (existing != null)
            {
                return Conflict($"Employee with Id {employee.Id} already exist");
            }

            _employeeService.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id) 
            {
                return BadRequest("Add matched Ids");
            }

            var existing = _employeeService.GetById(id);
            if (existing == null) 
            {
                return NotFound();
            }

            _employeeService.Update(id, employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _employeeService.GetById(id);
            if (existing == null) 
            {
                return NotFound();
            }

            _employeeService.Delete(id);
            return NoContent();
        }




    }
}
