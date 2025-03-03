using EmployeeApi.models;
using EmployeeApi.Repos.Interfaces;
using EmployeeApi.Services;
using EmployeeApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace EmployeeApi.Tests.Services
{
    public class EmployeeServiceTests
    {
        private readonly IEmployeeService _employeeService;
        public readonly Mock<IEmployeesRepository> _employeeRepositoryMock;
        private readonly Mock<ILogger>_loggerMock;
        public EmployeeServiceTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeesRepository>();
            _loggerMock = new Mock<ILogger>();
        }

        [Fact]
        public async Task AddEmployee_Should_Add_Employee()
        {
            var employee = new EmployeeModel
            {
                Id = Guid.NewGuid(),
                FirstName = "Mike",
                IsActive = true
            };
            _employeeRepositoryMock.Setup(_employeeRepositoryMock => _employeeRepositoryMock.AddEmployee(It.IsAny<EmployeeModel>())).ReturnsAsync(employee);

            var result = await _employeeService.AddAsync(employee);

            Assert.NotNull(result);
            Assert.Equal("Mike", result.FirstName); 

        }   

    }
}
