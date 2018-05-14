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
        //const string ConnectionString = @"Data Source =.\; Initial Catalog = EmployeeDbDev; Integrated Security = False; User ID = sc9; Password=sc9Password;";
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeDbDev;Integrated Security=True;";

        public bool AddPlatePattern(PlatePatternDataModel platePattern)
        {
            if (platePattern == null)
            {
                return false;
            }

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Execute("spAddPlatePattern", platePattern, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<PlatePatternDataModel> GetPlatePatterns(int plateId)
        {
            if (plateId <= 0)
            {
                return Enumerable.Empty<PlatePatternDataModel>();
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                var patterns = connection.Query<PlatePatternDataModel>($"select * from PlatePattern where [PlateId]={plateId}");
                return patterns;
            }
        }

        public PlatePatternDataModel GetPlatePattern(int plateId, int platePatternId)
        {
            if (plateId <= 0 || platePatternId <= 0)
            {
                return null;
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                var pattern = connection.QueryFirst<PlatePatternDataModel>("spGetPlatePattern", new { id = platePatternId, plateId = plateId });
                return pattern;
            }

            return null;
        }
    }
}
