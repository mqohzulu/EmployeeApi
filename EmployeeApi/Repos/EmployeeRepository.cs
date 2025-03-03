using EmployeeApi.models;
using EmployeeApi.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repos
{
    public class EmployeeRepository : IEmployeesRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(AppDbContext context, ILogger<EmployeeRepository> _Logger )
        {
            _context = context;
            _logger = _Logger;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll(bool active_only)
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<EmployeeModel> GetEmployee(Guid id)
        {
            return await _context.Employees?.FirstOrDefaultAsync(e => e.Id == id)
                    ?? throw new KeyNotFoundException($"Employee with ID {id} not found.");
        }   

        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            try
            {

                var exist_employee = await _context.Employees.FindAsync(employee.Id);
                if (exist_employee != null)
                {
                    _logger.LogWarning("Employee with ID: {EmployeeId} already exists.", employee.Id);
                    throw new InvalidOperationException("Employee already exists.");
                }

                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();

                return employee;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding employee with ID: {EmployeeId}", employee.Id);
                throw;
            }
        }

        public async Task<EmployeeModel> UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating employee with ID: {EmployeeId}", employee.Id);
                throw;
            }

        }
        public async Task DeleteEmployee(Guid id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee is not null)
                {
                    employee.active = false;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting employee with ID: {EmployeeId}", id);
                throw;
            }
           
        }


    }
}
