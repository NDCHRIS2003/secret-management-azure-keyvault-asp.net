using EmployeeRecordMvcAPI.Data;
using EmployeeRecordMvcAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordMvcAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            var emp = await _context.Employees.AddAsync(employee);
            return emp.Entity;
        }

        public async Task<int?> DeleteEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id.Equals(id));
            _context.Employees.Remove(employee!);
            return employee!.Id;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync( e => e.Id.Equals(id));
            return employee!;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetEmployeeByIdAsync<T>(object id)
        {
            return await GetEmployeeByIdAsync<T>(id);
        }
    }
}
