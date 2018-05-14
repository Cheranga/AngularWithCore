import { Component} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PlateService } from "../../Services/plateservice.service";

@Component({
    selector: 'addpatternnew',
    templateUrl: './addpatternnew.component.html'
})

export class AddPatternNewComponent {
    private charId:number = 0;
    patternName: string = '';
    title: string = "Create";
    id: number;
    patternId: number;
    errorMessage: any;
    min: number;
    max: number;
    sub: any;
    disableAdd: boolean = false;
    characterId:number = 0;

    characters: ICharacterData[] = [];

    constructor(private _avRoute: ActivatedRoute, private _plateService: PlateService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        if (this._avRoute.snapshot.params["patternId"]) {
            this.patternId = this._avRoute.snapshot.params["patternId"];
        }

        this.title = this.patternId > 0 ? "Edit Pattern" : "Create Pattern";

        this.sub = this._avRoute.queryParams.subscribe(params => {
            this.min = +params['min'] || 0;
            this.max = +params['max'] || 0;

        });
    }

    addCharacter() {
        if (!this.disableAdd) {
            this.characters.push({
                id:++this.charId,
                include: 'A-Z',
                exclude: '',
                placedIn: 0,
                minOccurences: 1,
                maxOccurences: 1
            });

            this.disableAdd = this.characters.length >= this.max;
        }
    }

    deleteAllCharacters() {
        this.characters.splice(0, this.characters.length);
        this.charId = 0;
        this.disableAdd = false;
    }

    deleteCharacter(character: ICharacterData) {
        if (character) {
            const index = this.characters.indexOf(character);
            if (index >= 0) {
                this.characters.splice(index, 1);
                this.disableAdd = false;
            }
        }
    }

    saveCharacter(character: ICharacterData) {
        if (!this.disableAdd && character) {
            this.characters.push(character);
            if (this.characters.length >= this.max) {
                this.disableAdd = true;
            }
        }
    }

    savePattern() {
        var platePatternData: INewPlatePatternPostData = {
            patternId: this.patternId,
            name: this.patternName,
            plateId: this.id,
            characters: this.characters
        };

        this._plateService.savePlatePattern(platePatternData)
            .subscribe((data) => {
                this._router.navigate(['/plate/patterns/', this.id]);
            }, error => this.errorMessage = error);
    }
}

interface ICharacterData {
    id:number;
    include: string;
    exclude: string;
    placedIn: number;
    minOccurences: number;
    maxOccurences: number;
}

interface INewPlatePatternPostData {
    plateId: number;
    patternId: number;
    name: string;
    characters: ICharacterData[];
}