import { CharacterData } from "../models/characterdata";

export interface INewPlatePatternPostData {
    plateId: number;
    patternId: number;
    name: string;
    characters: CharacterData[];
}