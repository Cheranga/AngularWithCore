using System.Collections.Generic;
using ASPCoreWithAngular.Dto.Common;
using ASPCoreWithAngular.Models.VPlates;

namespace ASPCoreWithAngular.Dto.PlatePattern
{
    public class CreatePlatePattern
    {
        public int PlateId { get; set; }
        public int PatternId { get; set; }
        public string Name { get; set; }
        public IEnumerable<CreateCharacter> Characters { get; set; }
        public int MaxAllowed { get; set; }

        public CreatePlatePattern()
        {
            Characters = new List<CreateCharacter>();
        }
    }

    public class CreateCharacter
    {
        public FlowType FlowType { get; set; }
        public string Include { get; set; }
        public string Exclude { get; set; }
        public int MinOccurences { get; set; }
        public int MaxOccurences { get; set; }

    }

}
