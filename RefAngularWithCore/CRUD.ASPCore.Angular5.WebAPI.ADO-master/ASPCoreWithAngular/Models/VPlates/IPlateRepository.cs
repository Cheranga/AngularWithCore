using System.Collections.Generic;

namespace ASPCoreWithAngular.Models.VPlates
{
    public interface IPlateRepository
    {
        Plate GetPlate(int id);
        IEnumerable<Plate> GetAll();
        int AddPlate(Plate plate);
        bool DeletePlate(int id);
    }
}