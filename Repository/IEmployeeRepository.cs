using EmployeeRecordMvcAPI.Domain;

namespace EmployeeRecordMvcAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByIdAsync(int id);

        Task<Employee> CreateEmployeeAsync(Employee employee);

        Task<int?> DeleteEmployeeByIdAsync(int id);

        Task SaveChangesAsync();
    }
}
