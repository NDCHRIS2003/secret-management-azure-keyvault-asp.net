using AutoMapper;
using EmployeeRecordMvcAPI.Domain;
using EmployeeRecordMvcAPI.Dtos;
using EmployeeRecordMvcAPI.Repository;

namespace EmployeeRecordMvcAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;
        private IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EmployeeCreateDto> CreateEmployeeAsync(EmployeeCreateDto employeeDto)
        {
            if (string.IsNullOrEmpty(employeeDto.Email))
            {
                throw new ArgumentNullException(nameof(employeeDto.Email));
            }
            var employee = _mapper.Map<Employee>(employeeDto);
            await _repository.CreateEmployeeAsync(employee);
            await _repository.SaveChangesAsync();
            return employeeDto;
        }

        public async Task<int?> DeleteEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            //ArgumentNullException.ThrowIfNull(nameof(employee));
            if (employee is null)
            {
                return null;
            }
            await _repository.DeleteEmployeeByIdAsync(employee.Id);
            await _repository.SaveChangesAsync();
            return employee.Id;
        }

        public async Task<IEnumerable<EmployeeReadDto>> GetAllEmployeesAsync()
        {
            var employees = await _repository.GetAllEmployeesAsync();
            return _mapper.Map<IEnumerable<EmployeeReadDto>>(employees);
        }

        public async Task<EmployeeReadDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            
            return _mapper.Map<EmployeeReadDto>(employee);
        }

        public async Task<EmployeeUpdateDto?> UpdateEmployeeAsync(EmployeeUpdateDto employeeDto, int id)
        {
            var employee = await _repository.GetEmployeeByIdAsync(id);
            if (employee is null)
                return null;
            _mapper.Map(employeeDto, employee);
            await _repository.SaveChangesAsync();
            return employeeDto;
        }
    }
}
