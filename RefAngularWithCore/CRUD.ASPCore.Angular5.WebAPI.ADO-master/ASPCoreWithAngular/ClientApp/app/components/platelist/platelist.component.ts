import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { PlateService } from "../../Services/plateservice.service"

@Component({
    selector: 'platelist',
    templateUrl: './platelist.component.html'
})

export class PlateListComponent {
    public plateList: PlateData[];

    constructor(public http: Http, private _router: Router, private _plateService: PlateService) {
        this.getPlates();
    }

    getPlates() {
        this._plateService.getPlates().subscribe(
            data => this.plateList = data
        )
    }

    delete(plateId) {
        var ans = confirm("Do you want to delete this plate?");
        if (ans) {
            this._plateService.deletePlate(plateId).subscribe((data) => {
                this.getPlates();
            }, error => console.error(error))
        }
    }
}

interface PlateData {
    id: number;
    name: string;
    minCharacters: number;
    maxCharacters: number;
}