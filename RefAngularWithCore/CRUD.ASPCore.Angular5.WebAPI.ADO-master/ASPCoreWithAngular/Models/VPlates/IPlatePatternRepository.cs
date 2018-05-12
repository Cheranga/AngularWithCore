using System.Collections.Generic;

namespace ASPCoreWithAngular.Models.VPlates
{
    public interface IPlatePatternRepository
    {
        bool AddPlatePattern(PlatePattern platePattern);
        bool EditPlatePattern(PlatePattern platePattern);
        IEnumerable<PlatePattern> GetPlatePatterns(int plateId);
        PlatePattern GetPlatePattern(int plateId, int platePatternId);
    }
}