using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace AngularWithCore.Models
{
    public class EmployeeDataAccessLayer
    {
        private string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=EmployeeDbDev;Trusted_Connection=True;MultipleActiveResultSets=true";

        public List<Employee> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var employees = connection.Query<Employee>("spGetAllEmployees", commandType: CommandType.StoredProcedure).ToList();
                return employees;
            }
        }

        public int AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return 0;
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("spAddEmployee", 
                    new{employee.Name, employee.City, employee.Gender, employee.Department}, 
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return 0;
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("spUpdateEmployee", employee);
            }
        }

        public int DeleteEmployee(int id)
        {
            using (var connectopn = new SqlConnection(_connectionString))
            {
                connectopn.Execute("spDeleteEmployee",new{id}, commandType:CommandType.StoredProcedure);
            }

            return 1;
        }

        public Employee GetEmployee(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = $"select top 1 from tblEmployee where id={id}";

                return connection.QueryFirstOrDefault<Employee>(query);
            }
        }
    }
}
