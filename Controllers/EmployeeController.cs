using EmployeeRecordMvcAPI.Dtos;
using EmployeeRecordMvcAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRecordMvcAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController( IEmployeeService service)
        {
            _service = service;
        }


        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<EmployeeReadDto>>> GetEmployeesAsync()
        {
            var employees = await _service.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReadDto>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _service.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeCreateDto>> CreateEmployeeAsync([FromBody]EmployeeCreateDto employeCreateDto)
        {
            var employee = await _service.CreateEmployeeAsync(employeCreateDto);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEmployeeAsync(int id)
        {
            var employeeId = await _service.DeleteEmployeeByIdAsync(id);
            return employeeId is not null ? Ok(employeeId) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeUpdateDto>> UpdateEmployeeAsync([FromBody]EmployeeUpdateDto employeeUpdateDto, int id)
        {
            var employee = await _service.UpdateEmployeeAsync(employeeUpdateDto, id);
            return employee is not null ? Ok(employee) : NotFound();
        }
    }
}
