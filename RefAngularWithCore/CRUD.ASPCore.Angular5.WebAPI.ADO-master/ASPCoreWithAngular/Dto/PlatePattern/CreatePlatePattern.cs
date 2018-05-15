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

            var flowTypeText = GetFlowTypeDisplay(FlowType);
            var includeText = $"'{Include}'";
            var excludeText = string.IsNullOrEmpty(Exclude) ? string.Empty : $"but excluding '{Exclude}'";
            var minText = string.Empty;
            var maxText = string.Empty;
            if (MinOccurences.HasValue && MaxOccurences.HasValue)
            {
                minText = $"with a minimum of {MinOccurences}";
                maxText = $"and maximum of {MaxOccurences} occurences";
            }
            else if (MinOccurences.HasValue)
            {
                minText = $"with a minimum of {MinOccurences} occurences";
            }
            else if (MaxOccurences.HasValue)
            {
                maxText = $"with a maximum of {MaxOccurences} occurences";
            }

            var message = string.Format(messagePattern, flowTypeText, includeText, excludeText, minText, maxText);

            return message;
        }

        public string GetFlowTypeDisplay(FlowType flowType)
        {
            switch (flowType)
            {
                case FlowType.StartsWith:
                    return "Starts with";
                case FlowType.StartsWithPattern:
                    return "Starts with pattern";
                case FlowType.Contains:
                    return "Contains";
                case FlowType.ContainsPattern:
                    return "Contains pattern";
                case FlowType.EndsWith:
                    return "Ends with";
                case FlowType.EndsWithPattern:
                    return "Ends with pattern";
                default:
                    return "Contains";
            }
        }

    }

}
