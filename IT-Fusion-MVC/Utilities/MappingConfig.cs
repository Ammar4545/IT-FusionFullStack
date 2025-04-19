

using AutoMapper;
using IT_Fusion_MVC.Dtos;
using IT_Fusion_MVC.Models;

namespace IT_Fusion_MVC.Utilities
{
    public class MappingConfig : Profile
    {
       public MappingConfig() 
       {
            //CreateMap<Employee , EmployeeDto>().ReverseMap;
            //CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();

            //CreateMap<Department, DepartmentDto>().ReverseMap();
            //CreateMap<DepartmentCreateDto, Department>();
        }
    }
}
