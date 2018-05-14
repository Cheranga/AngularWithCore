import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { PlateListComponent } from "../platelist/platelist.component";
import { PlateService } from "../../Services/plateservice.service";

@Component({
    selector: 'addpattern',
    templateUrl: './addpattern.component.html'
})

export class AddPatternComponent {
    addPatternForm: FormGroup;
    patternName: string = '';
    title: string = "Create";
    id: number;
    patternId:number;
    errorMessage: any;
    min: number;
    max:number;
    sub: any;

    patternDataList:IPatternData[] = [];

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _plateService: PlateService, private _router: Router) {
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

            for (var i = 0; i < this.max; i++) {
                var pattern: IPatternData = {
                    characterType: 0,
                    include: 'A-Z',
                    exclude:''
                };

                this.patternDataList.push(pattern);
            }

        });
    }

    save() {
        var platePatternData: IPlatePatternPostData = {
            id: this.patternId,
            name:this.patternName,
            plateId: this.id,
            characters:this.patternDataList
        }

        this._plateService.savePlatePattern(platePatternData)
            .subscribe((data) => {
                    this._router.navigate(['/plate/patterns/', this.id]);
                },
                error => this.errorMessage = error);
    }
}

interface IPatternData {
    characterType: number;
    include: string;
    exclude:string;
}

interface IPlatePatternPostData {
    id: number;
    name:string;
    plateId: number;
    characters:IPatternData[];
}