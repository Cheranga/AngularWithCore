import { Component} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PlateService } from "../../Services/plateservice.service";
import { UppercaseDirective } from "../../directives/uppercase.directive";
import {CharacterData} from "../../models/characterdata";
import { INewPlatePatternPostData} from "../../interfaces/inewplatepatternpostdata";


@Component({
    selector: 'addplatepattern',
    templateUrl: './addplatepattern.component.html'
})

export class AddPlatePatternComponent {
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

    characters: CharacterData[] = [];

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
            const newCharacter = new CharacterData();
            newCharacter.id = ++this.charId;
            newCharacter.include = 'A-Z';
            newCharacter.exclude = '';
            newCharacter.placedIn = 0;


            this.characters.push(newCharacter);

            this.disableAdd = this.characters.length >= this.max;
        }
    }

    deleteAllCharacters() {
        this.characters.splice(0, this.characters.length);
        this.charId = 0;
        this.disableAdd = false;
    }

    deleteCharacter(character: CharacterData) {
        if (character) {
            const index = this.characters.indexOf(character);
            if (index >= 0) {
                this.characters.splice(index, 1);
                this.disableAdd = false;
            }
        }
    }

    saveCharacter(character: CharacterData) {
        if (!this.disableAdd && character) {
            this.characters.push(character);
            if (this.characters.length >= this.max) {
                this.disableAdd = true;
            }
        }
    }

    savePattern() {
        var platePatternData: INewPlatePatternPostData = {
            plateId: this.id,
            patternId: this.patternId,
            name: this.patternName,
            characters: this.characters
        };

        this._plateService.savePlatePattern(platePatternData)
            .subscribe((data) => {
                this._router.navigate(['/plate/patterns/', this.id]);
            }, error => this.errorMessage = error);
    }
}








