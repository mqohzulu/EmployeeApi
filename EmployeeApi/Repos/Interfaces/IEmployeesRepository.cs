using EmployeeApi.models;

namespace EmployeeApi.Repos.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<EmployeeModel>> GetAll(bool active_only);
        Task<EmployeeModel> GetEmployee(Guid id);
        Task<EmployeeModel> AddEmployee(EmployeeModel employee);
        Task<EmployeeModel> UpdateEmployee(EmployeeModel employee);
        Task DeleteEmployee(Guid id);
    }
}
