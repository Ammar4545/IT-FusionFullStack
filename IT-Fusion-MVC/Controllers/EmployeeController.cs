
using ADVA_FrontEnd.Services.IServices;
using AutoMapper;
using IT_Fusion_MVC.Dtos;
using IT_Fusion_MVC.Models;
using IT_Fusion_MVC.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADVA_FrontEnd.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> employees = await _employeeService.GetAsync(url: $"{SD.ITFusionBaseUrl}/Employees");

            List<EmployeeDto> employeesDtos = _mapper.Map<List<EmployeeDto>>(employees);

            return View(employeesDtos);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDto employeeDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Employee employee = _mapper.Map<Employee>(employeeDto);
            await _employeeService.PostAsync(url: $"{SD.ITFusionBaseUrl}/employees", data: employee);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int employeeId)
        {
            Employee employee = await _employeeService.GetByIdAsync(url: $"{SD.ITFusionBaseUrl}/employees/{employeeId}");

            EmployeeUpdateDto employeeUpdateDt = _mapper.Map<EmployeeUpdateDto>(employee);
            return View(employeeUpdateDt);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeUpdateDto employeeUpdateDto, int employeeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Employee employee = _mapper.Map<Employee>(employeeUpdateDto);
            await _employeeService.UpdateAsync(url: $"{SD.ITFusionBaseUrl}/employees/{employeeId}", data: employee);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            await _employeeService.Delete(url: $"{SD.ITFusionBaseUrl}/employees/{employeeId}");
            return RedirectToAction(nameof(Index));
        }
    }
}
