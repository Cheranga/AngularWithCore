import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class PlateService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getPlates() {
        return this._http.get(this.myAppUrl + 'api/Plate')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getPlate(plateId) {
        return this._http.get(this.myAppUrl + 'api/Plate/Patterns/' + plateId)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    savePlate(plate) {
        return this._http.post(this.myAppUrl + 'api/Plate/Create', plate)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    savePlatePattern(platePattern) {
        return this._http.post(this.myAppUrl + 'api/plate/patterns/create', platePattern)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deletePlate(id) {
        return this._http.delete(this.myAppUrl + "api/Plate/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}