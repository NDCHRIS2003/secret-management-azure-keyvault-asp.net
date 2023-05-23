using EmployeeRecordMvcAPI.Dtos;

namespace EmployeeRecordMvcAPI.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeReadDto>> GetAllEmployeesAsync();

        Task<EmployeeReadDto> GetEmployeeByIdAsync(int id);

        Task<EmployeeCreateDto> CreateEmployeeAsync(EmployeeCreateDto employeeDto);

        Task<int?> DeleteEmployeeByIdAsync(int id);

        Task<EmployeeUpdateDto?> UpdateEmployeeAsync(EmployeeUpdateDto employeeDto, int id);
    }
}
