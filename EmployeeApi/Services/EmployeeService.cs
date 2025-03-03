using EmployeeApi.models;
using EmployeeApi.Repos.Interfaces;
using EmployeeApi.Services.Interfaces;

namespace EmployeeApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeesRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<EmployeeModel> GetByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching employee with ID: {EmployeeId}", id);

            var employee = await _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                _logger.LogWarning("Employee with ID: {EmployeeId} not found", id);
                throw new KeyNotFoundException("Employee not found.");
            }

            return employee;
        }
        public async Task<EmployeeModel> AddAsync(EmployeeModel employee)
        {
            _logger.LogInformation("Adding employee: {@Employee}", employee);

            var existingEmployee = await _employeeRepository.GetEmployee(employee.Id);
            if (existingEmployee != null)
            {
                _logger.LogWarning("Employee with ID: {EmployeeId} already exists.", employee.Id);
                throw new InvalidOperationException("Employee already exists.");
            }

            return await _employeeRepository.AddEmployee(employee);
        }

        public async Task UpdateAsync(EmployeeModel employee)
        {
            _logger.LogInformation("Updating employee with ID: {EmployeeId}", employee.Id);

            var existingEmployee = await _employeeRepository.GetEmployee(employee.Id);
            if (existingEmployee == null)
            {
                _logger.LogWarning("Cannot update, employee with ID: {EmployeeId} not found.", employee.Id);
                throw new KeyNotFoundException("Employee not found.");
            }

            await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            _logger.LogInformation("Soft deleting employee with ID: {EmployeeId}", id);

            var existingEmployee = await _employeeRepository.GetEmployee(id);
            if (existingEmployee == null)
            {
                _logger.LogWarning("Cannot delete, employee with ID: {EmployeeId} not found.", id);
                throw new KeyNotFoundException("Employee not found.");
            }

            await _employeeRepository.DeleteEmployee(id);
        }
    }

}
