using IT_Fusion_MVC.Services.IServices;
using IT_Fusion_MVC.Models;

namespace IT_Fusion_MVC.Services
{
    public class EmployeeService : RestSharpService<Employee>,IEmployeeService
    {
    }
}
