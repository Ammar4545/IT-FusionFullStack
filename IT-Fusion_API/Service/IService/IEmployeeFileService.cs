using IT_Fusion_API.Models;

namespace IT_Fusion_API.Service.IService
{
    public interface IEmployeeFileService
    {
        List<Employee> GetAll();
        Employee? GetById(int id);
        void Add(Employee employee);
        void Update(int id, Employee updatedEmployee);
        void Delete(int id);
    }
}
