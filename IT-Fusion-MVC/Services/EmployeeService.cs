using ADVA_FrontEnd.Services.IServices;
using IT_Fusion_MVC.Models;

namespace ADVA_FrontEnd.Services
{
    public class EmployeeService : RestSharpService<Employee>,IEmployeeService
    {
    }
}
