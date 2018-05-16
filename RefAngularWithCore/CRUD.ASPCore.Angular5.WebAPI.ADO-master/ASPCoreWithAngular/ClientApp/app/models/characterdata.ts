import { FlowType } from "./flowtype";

export class CharacterData {
    id: number;
    flowType: FlowType = FlowType.Contains;
    include: string;
    exclude: string;
    minOccurences?: number;
    maxOccurences?: number;

    private _placedIn: number;
    private _isDisabled: boolean = true;

    get placedIn(): number {
        return this._placedIn;
    }

    set placedIn(newValue: number) {
        this._placedIn = newValue;
        this._isDisabled = this._placedIn == 0;
    }

    get isDisabled(): boolean {
        return this._isDisabled;
    }
}