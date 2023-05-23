using EmployeeRecordMvcAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecordMvcAPI.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options): base(options)
        {

        }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
