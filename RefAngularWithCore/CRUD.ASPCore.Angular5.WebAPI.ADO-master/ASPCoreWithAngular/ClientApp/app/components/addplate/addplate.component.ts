import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { PlateListComponent } from "../platelist/platelist.component";
import { PlateService } from "../../Services/plateservice.service";

@Component({
    selector: 'addplate',
    templateUrl: './addplate.component.html'
})

export class AddPlateComponent{
    plateForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _plateService: PlateService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.plateForm = this._fb.group({
            id: 0,
            name: ['', [Validators.required]],
            minCharacters: ['', [Validators.required]],
            maxCharacters: ['', [Validators.required]]
        });
    }

    save() {

        if (!this.plateForm.valid) {
            return;
        }

        this._plateService.savePlate(this.plateForm.value)
            .subscribe((data) => {
                this._router.navigate(['/plate-list']);
            }, error => this.errorMessage = error)

    }

    cancel() {
        this._router.navigate(['/plate-list']);
    }

    get name() { return this.plateForm.get('name'); }
    get minCharacters() { return this.plateForm.get('minCharacters'); }
    get maxCharacters() { return this.plateForm.get('maxCharacters'); }
}