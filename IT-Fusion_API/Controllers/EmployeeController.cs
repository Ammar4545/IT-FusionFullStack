using IT_Fusion_API.Models;
using IT_Fusion_API.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult GetAll() => Ok(_employeeService.GetAll());

        

    }
}
