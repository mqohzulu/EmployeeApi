using Castle.Core.Logging;
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
        public EmployeeServiceTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeesRepository>();
        }

    }
}
