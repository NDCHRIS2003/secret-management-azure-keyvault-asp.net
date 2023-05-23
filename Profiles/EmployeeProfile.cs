using AutoMapper;
using EmployeeRecordMvcAPI.Domain;
using EmployeeRecordMvcAPI.Dtos;

namespace EmployeeRecordMvcAPI.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Source to Destination
            CreateMap<EmployeeCreateDto, Employee>();

            CreateMap<EmployeeUpdateDto, Employee>(); 
            
            CreateMap<Employee, EmployeeReadDto>();
        }
    }
}
