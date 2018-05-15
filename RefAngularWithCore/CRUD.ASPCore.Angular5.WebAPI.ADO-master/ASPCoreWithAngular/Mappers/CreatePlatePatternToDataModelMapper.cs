using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreWithAngular.Dto.PlatePattern;
using ASPCoreWithAngular.Models.VPlates;

namespace ASPCoreWithAngular.Mappers
{
    public class CreatePlatePatternToDataModelMapper : DataMapper<CreatePlatePattern, PlatePatternDataModel>
    {
        public override PlatePatternDataModel Map(CreatePlatePattern source)
        {
            if (source?.Characters == null)
            {
                return null;
            }

            var letters = new List<CreateCharacter>(source.Characters);
            if (!letters.Any())
            {
                return null;

            }

            var pattern = string.Join("|", source.Characters.Select(x =>
            {
                var characterType = GetCharacterType(x);
                if (characterType == CharacterType.Invalid)
                {
                    return null;
                }

                var charType = characterType == CharacterType.Any ? "*" : characterType == CharacterType.Letters ? "L" : "N";
                return $"{charType}:{x.Include}:{x.Exclude}:{x.MinOccurences}:{x.MaxOccurences}";
            }).Where(x => x != null));

            if (string.IsNullOrEmpty(pattern))
            {
                return null;
            }

            return new PlatePatternDataModel
            {
                PlateId = source.PlateId,
                Name = source.Name,
                Pattern = pattern,
                PatternDisplay = string.Join("and ", source.Characters.Select(x=>x.GetDisplay()))
            };
        }
       

        public CharacterType GetCharacterType(CreateCharacter character)
        {
            if (string.IsNullOrEmpty(character?.Include))
            {
                return CharacterType.Invalid;
            }

            var firstChar = character.Include.First();
            var isAlphaNumeric = firstChar == '*';
            if (isAlphaNumeric)
            {
                return CharacterType.Any;
            }

            var characterValue = (int) character.Include.First();
            var isLetter = characterValue >= 65 && characterValue <= 91;
            if (isLetter)
            {
                return CharacterType.Letters;
            }

            var isNumber = characterValue >= 48 && characterValue <= 57;
            return isNumber ? CharacterType.Numbers : CharacterType.Invalid;
        }
    }
}
