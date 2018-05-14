using System.Collections.Generic;

namespace ASPCoreWithAngular.Models.VPlates
{
    public interface IPlatePatternRepository
    {
        bool AddPlatePattern(PlatePatternDataModel platePattern);
        bool EditPlatePattern(PlatePattern platePattern);
        IEnumerable<PlatePatternDataModel> GetPlatePatterns(int plateId);
        PlatePatternDataModel GetPlatePattern(int plateId, int platePatternId);
    }
}