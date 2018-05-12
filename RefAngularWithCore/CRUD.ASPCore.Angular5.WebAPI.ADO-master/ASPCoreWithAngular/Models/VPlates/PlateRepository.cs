using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace ASPCoreWithAngular.Models.VPlates
{
    public class PlateRepository : IPlateRepository
    {
        const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=EmployeeDbDev;Trusted_Connection=True;MultipleActiveResultSets=true";//"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myTestDB;Data Source=ANKIT-HP\\SQLEXPRESS";

        public bool AddPlate(Plate plate)
        {
            if(plate == null)
            {
                return false;
            }

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Execute("spAddPlate", plate, commandType: System.Data.CommandType.StoredProcedure);
                }

                return true;
            }
            catch(Exception ex)
            {

            }

            return false;
        }

        public bool DeletePlate(int id)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Execute("spDeletePlate", new { id }, commandType: System.Data.CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public IEnumerable<Plate> GetAll()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var plates = connection.Query<Plate>("select * from Plate");
                    return plates;
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public Plate GetPlate(int id)
        {
            if(id <= 0)
            {
                return null;
            }

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var plate = connection.QueryFirst<Plate>($"select top 1 * from Plate where [id]={id}");
                    return plate;
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }

}
