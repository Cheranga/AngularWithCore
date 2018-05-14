﻿namespace ASPCoreWithAngular.Models.VPlates
{
    public class Character
    {
        public CharacterType CharacterType { get; set; }
        public string Include { get; set; }
        public string Exclude { get; set; }
        public int MinOcccurences { get; set; }
        public int MaxOccurences { get; set; }
    }
}