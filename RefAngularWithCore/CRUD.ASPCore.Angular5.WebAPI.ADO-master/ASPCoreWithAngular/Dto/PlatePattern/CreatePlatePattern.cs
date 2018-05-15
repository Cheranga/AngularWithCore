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
        public int? MinOccurences { get; set; }
        public int? MaxOccurences { get; set; }

        public string GetDisplay()
        {
            var messagePattern = @"{0} {1} {2} {3} {4}";

            var flowTypeText = FlowType.ToString();
            var includeText = $"including {Include}";
            var excludeText = string.IsNullOrEmpty(Exclude) ? string.Empty : $"but excluding {Exclude}";
            var minText = MinOccurences.HasValue ? $"with a minimum of {MinOccurences}" : string.Empty;
            var maxText = MaxOccurences.HasValue && !string.IsNullOrEmpty(minText) ? $"and a maximum of {MaxOccurences} occurences" : $"with a maximum of {MaxOccurences}";
            
            var message = string.Format(messagePattern, flowTypeText, includeText, excludeText, minText, maxText);

            return message;
        }

    }

}
