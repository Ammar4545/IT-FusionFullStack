using AutoMapper;
using IT_Fusion_MVC.Dtos;
using IT_Fusion_MVC.Models;

namespace IT_Fusion_MVC.Utilities
{
    public class MappingConfig : Profile
    {
       public MappingConfig() 
       {
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
        }
    }
}
