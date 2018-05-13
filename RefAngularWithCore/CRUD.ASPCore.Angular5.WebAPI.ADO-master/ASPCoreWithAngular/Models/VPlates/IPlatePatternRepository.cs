using System.Collections.Generic;

namespace ASPCoreWithAngular.Models.VPlates
{
    public interface IPlatePatternRepository
    {
        bool AddPlatePattern(PlaterPatternDataModel platePattern);
        bool EditPlatePattern(PlatePattern platePattern);
        IEnumerable<PlaterPatternDataModel> GetPlatePatterns(int plateId);
        PlaterPatternDataModel GetPlatePattern(int plateId, int platePatternId);
    }
}