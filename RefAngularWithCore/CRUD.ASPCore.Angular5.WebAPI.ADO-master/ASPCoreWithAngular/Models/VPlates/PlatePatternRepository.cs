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
        const string ConnectionString = @"Data Source =.\; Initial Catalog = EmployeeDbDev; Integrated Security = False; User ID = sc9; Password=sc9Password;";

        public bool AddPlatePattern(PlaterPatternDataModel platePattern)
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

        public IEnumerable<PlaterPatternDataModel> GetPlatePatterns(int plateId)
        {
            if (plateId <= 0)
            {
                return Enumerable.Empty<PlaterPatternDataModel>();
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                var patterns = connection.Query<PlaterPatternDataModel>($"select * from PlatePattern where [PlateId]={plateId}");
                return patterns;
            }
        }

        public PlaterPatternDataModel GetPlatePattern(int plateId, int platePatternId)
        {
            if (plateId <= 0 || platePatternId <= 0)
            {
                return null;
            }

            using (var connection = new SqlConnection(ConnectionString))
            {
                var pattern = connection.QueryFirst<PlaterPatternDataModel>("spGetPlatePattern", new { id = platePatternId, plateId = plateId });
                return pattern;
            }

            return null;
        }
    }
}
