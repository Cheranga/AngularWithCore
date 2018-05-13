using System.Collections.Generic;
using System.Linq;

namespace ASPCoreWithAngular.Models.VPlates
{
    public class MockedPlateRepository : IPlateRepository
    {
        private readonly List<Plate> _plates;

        public MockedPlateRepository()
        {
            _plates = new List<Plate>();
        }

        public Plate GetPlate(int id)
        {
            return _plates.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Plate> GetAll()
        {
            return _plates;
        }

        public bool AddPlate(Plate plate)
        {
            if (plate == null)
            {
                return false;
            }

            _plates.Add(plate);
            return true;
        }
        

        public bool DeletePlate(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var plate = GetPlate(id);
            if (plate == null)
            {
                return false;
            }

            _plates.Remove(plate);

            return true;
        }
    }
}
