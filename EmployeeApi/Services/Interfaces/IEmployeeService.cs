using EmployeeApi.models;

namespace EmployeeApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> GetByIdAsync(Guid id);
        Task<EmployeeModel> AddAsync(EmployeeModel employee);
        Task UpdateAsync(EmployeeModel employee);
        Task SoftDeleteAsync(Guid id);
    }
}
