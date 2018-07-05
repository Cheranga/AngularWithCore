using System;
using AngularWithCore.Models;
using Xunit;

namespace DataAccess.Tests
{
    public class EmployeeDataAccessTests
    {
        [Fact]
        public void GetAllEmployees()
        {
            var dataAccess = new EmployeeDataAccessLayer();
            var employees = dataAccess.GetAll();

        }

        [Fact]
        public void AddEmployee()
        {
            var employee = new Employee
            {
                Name = "Cheranga",
                Department = "IT",
                City = "Melbourne",
                Gender = "Male"
            };

            var dataAccess = new EmployeeDataAccessLayer();
            var result = dataAccess.AddEmployee(employee);

            Assert.Equal(1, result);
        }

        [Fact]
        public void UpdateEmployee()
        {
           
        }

    }
}
