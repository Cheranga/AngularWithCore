using System.Collections.Generic;

namespace ASPCoreWithAngular.Models.VPlates
{
    public class Plate
    {
        public Plate()
        {
            Patterns = new List<PlatePattern>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MinCharacters { get; set; }
        public int MaxCharacters { get; set; }
        public IEnumerable<PlatePattern> Patterns { get; set; }
    }
}