using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ASPCoreWithAngular.Models.VPlates
{
    public class PlatePatternRepository : IPlatePatternRepository
    {
        const string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=EmployeeDbDev;Trusted_Connection=True;MultipleActiveResultSets=true";//"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myTestDB;Data Source=ANKIT-HP\\SQLEXPRESS";

        public bool AddPlatePattern(PlatePattern platePattern)
        {
            if (platePattern == null)
            {
                return false;
            }

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Execute("spAddPlatePattern", 
                        new {platePattern.Name, Pattern = platePattern.GetFormat()}, 
                        commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception exception)
            {

            }

            return false;
        }

        public bool EditPlatePattern(PlatePattern platePattern)
        {
            if (platePattern == null)
            {
                return false;
            }

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Execute("spUpdatePlatePattern", 
                        new { platePattern.Id, platePattern.Name, Pattern = platePattern.GetFormat() }, 
                        commandType: CommandType.StoredProcedure);
                }

                return true;
            }
            catch (Exception exception)
            {

            }

            return false;
        }

        public IEnumerable<PlatePattern> GetPlatePatterns(int plateId)
        {
            if (plateId <= 0)
            {
                return null;
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                var patterns = connection.Query<PlatePattern>("select * from PlatePattern");
                return patterns;
            }

            return null;
        }

        public PlatePattern GetPlatePattern(int plateId, int platePatternId)
        {
            if (plateId <= 0 || platePatternId <= 0)
            {
                return null;
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                var pattern = connection.QueryFirst<PlatePattern>("spGetPlatePattern", new{id=platePatternId, plateId=plateId});
                return pattern;
            }

            return null;
        }
    }
}
