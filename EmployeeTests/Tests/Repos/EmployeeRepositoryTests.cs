using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using EmployeeApi.models;
using EmployeeApi.Repos.Interfaces;
using EmployeeApi.Repos;
using Microsoft.Extensions.Logging;
namespace EmployeeApi.Tests.Repos
{
    public class EmployeeRepositoryTests
    {
        private readonly AppDbContext _context;
        private readonly IEmployeesRepository _employeeRepository;
        private readonly Mock<ILogger<EmployeeRepository>> _Logger;  

        public EmployeeRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeTest")
                .Options;
            _context = new AppDbContext(options);
            _Logger = new Mock<ILogger<EmployeeRepository>>();
            _employeeRepository = new EmployeeRepository(_context, _Logger.Object);
        }

        [Fact]
        public async Task AddEmployee_Should_Add_Employee()
        {
            var employee = new EmployeeModel
            {
                Id = Guid.NewGuid(),
                FirstName = "John Doe",
                IsActive = true
            };

            var result = await _employeeRepository.AddEmployee(employee);
            Assert.NotNull(result);
            Assert.Equal("John Doe", result.FirstName);   
        }


    }
}
