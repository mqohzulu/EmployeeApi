using EmployeeApi.models;
using EmployeeApi.Repos.Interfaces;
using EmployeeApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IEmployeeService _employeesService;
        public EmployeeController(IEmployeesRepository employeesRepository,IEmployeeService employeeService) 
        {
            _employeesRepository = employeesRepository;
            _employeesService = employeeService;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAll(bool active_only)
        {
            var employees = await _employeesRepository.GetAll(active_only);
            return Ok(employees);
            
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {

            var employee = await _employeesService.GetByIdAsync(id);
            return Ok(employee);

        }
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeModel employee)
        {
           
            var new_employee = await _employeesService.AddAsync(employee);
            return Ok(new_employee);

        }
        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeModel employee)
        {

            await _employeesService.UpdateAsync(employee);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            await _employeesRepository.DeleteEmployee(id);
            return Ok();
        }   
    }
}
