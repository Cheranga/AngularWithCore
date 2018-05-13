using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ASPCoreWithAngular.Models
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=EmployeeDbDev;Trusted_Connection=True;MultipleActiveResultSets=true";//"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myTestDB;Data Source=ANKIT-HP\\SQLEXPRESS";

        //To View all employees details
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Employee>("spGetAllEmployees", commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                return null;
            }
        }

        //To Add new employee record 
        public int AddEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    return connection.Execute("spAddEmployee", 
                        new{employee.Name, employee.City, employee.Department, employee.Gender},
                        commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                return 0;
            }
        }

        //To Update the records of a particluar employee
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    return connection.Execute("spUpdateEmployee", employee, commandType: CommandType.StoredProcedure);
                }
            }
            catch
            {
                return 0;
            }
        }

        //Get the details of a particular employee
        public Employee GetEmployeeData(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = $"select top 1 * from tblEmployee where id={id}";
                    return connection.QueryFirst<Employee>(sql);
                }
            }
            catch
            {
                return null;
            }
        }

        //To Delete the record on a particular employee
        public int DeleteEmployee(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Execute("spDeleteEmployee", new {id}, commandType: CommandType.StoredProcedure);
                }

                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
