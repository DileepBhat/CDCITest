using ArithematicAPIService.v1;
using ArithematicAPIService.v1.Controllers;
using ArithematicAPIService.v1.Data;
using ArithematicAPIService.v1.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Arithematic.Service.v1.Tests
{
    public class EmployeeControllerTest
    {
        private EmployeeDataContext _employeeDataContext;

        [OneTimeSetUp]
        public void SetUp()
        {
            var dbOptionsBuilder = new DbContextOptionsBuilder<EmployeeDataContext>(new DbContextOptions<EmployeeDataContext>());
            dbOptionsBuilder.UseNpgsql("Server=127.0.0.1;port=5432;user id=service_account;password=service;database=employee_db;pooling=true");
            _employeeDataContext = new EmployeeDataContext(dbOptionsBuilder.Options);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _employeeDataContext.Dispose();
        }

        [Test]
        public void GivenAEmployeeController_PerformCurdOperations_AllOperationsShouldBeSuccessful()
        {
            var controller = new EmployeeController(_employeeDataContext);

            var employee = new Employee
            {
                Name = "Dileep Bhat",

                Address = new Address
                {
                    Country = "India",
                    State = "Karnataka",
                    City = "Udupi"
                }
            };

            var employeeId = controller.Add(employee);
            Assert.That(employeeId > 0, "Employeed id is not valid");

            var employeeLoaded = controller.GetEmployee(employeeId);
            Assert.That(employeeLoaded.Name == employee.Name, "Name parameter does not match");

            var address = employee.Address;
            var addressLoaded = employeeLoaded.Address;

            Assert.That(addressLoaded.Country == address.Country, "Country parameter does not match");
            Assert.That(addressLoaded.State == address.State, "State parameter does not match");
            Assert.That(addressLoaded.City == address.City, "City parameter does not match");

            employee.Name = "Dileep";
            employee.Address.City = "Bangalore";

            controller.UpdateEmployee(employee);
            employeeLoaded = controller.GetEmployee(employeeId);
            Assert.That(employeeLoaded.Name == "Dileep", "Name parameter does not match");

            addressLoaded = employeeLoaded.Address;

            Assert.That(addressLoaded.Country == "India", "Country parameter does not match");
            Assert.That(addressLoaded.State == "Karnataka", "State parameter does not match");
            Assert.That(addressLoaded.City == "Bangalore", "City parameter does not match");

            controller.DeleteEmployee(employee.EmployeeId);

            employeeLoaded = controller.GetEmployee(employeeId);
            Assert.That(employeeLoaded == null, "Employee should be deleted");
        }
    }
}