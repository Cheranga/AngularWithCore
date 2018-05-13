import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { PlateService } from "../../Services/plateservice.service";

@Component({
    selector: 'platedetail',
    templateUrl: './platedetail.component.html'
})

export class PlateDetailComponent{
    public plateDetail: IPlateDetailData;

    constructor(public http: Http, private _router: Router, private _avRoute:ActivatedRoute,
        private _plateService: PlateService) {
        if (this._avRoute.snapshot.params["id"]) {
            this.getPlate(this._avRoute.snapshot.params["id"]);
        }
    }

    getPlate(plateId) {
        this._plateService.getPlate(plateId).subscribe(
            data => this.plateDetail = data
        )
    }
}

interface IPlateDetailData {
    id: number;
    name: string;
    minCharacters: number;
    maxCharacters: number;
    patterns:IPlaterPatternData[];
}

interface IPlaterPatternData {
    name: string;
    pattern:string;
}
