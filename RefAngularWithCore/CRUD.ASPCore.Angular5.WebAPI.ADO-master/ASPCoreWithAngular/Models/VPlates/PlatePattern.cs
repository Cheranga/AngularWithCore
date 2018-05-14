using System.Collections.Generic;
using System.Linq;

namespace ASPCoreWithAngular.Models.VPlates
{
    public class PlatePattern
    {
        public PlatePattern()
        {
            Characters = new List<Character>();
        }

        public int Id { get; set; }
        public int PlateId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Character> Characters { get; set; }

        public string GetFormat()
        {
            var characters = new List<Character>(Characters);
            if (!characters.Any())
            {
                return string.Empty;
            }

            var pattern = string.Join("|", characters.Select(x =>
            {
                var charaterType = x.CharacterType == CharacterType.Letters ? "C" : "N";

                return $"{charaterType} : {x.Include} : {x.Exclude}";
            }));

            return pattern;
        }
    }
}