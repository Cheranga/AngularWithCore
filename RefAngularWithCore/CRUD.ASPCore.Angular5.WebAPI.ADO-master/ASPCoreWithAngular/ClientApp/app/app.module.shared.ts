import { NgModule } from '@angular/core';
import { EmployeeService } from './services/empservice.service'
import { PlateService } from "./Services/plateservice.service"
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
//import { FetchEmployeeComponent } from './components/fetchemployee/fetchemployee.component'
//import { createemployee } from './components/addemployee/AddEmployee.component'
import { PlateListComponent } from "./components/platelist/platelist.component"
import { AddPlateComponent } from "./components/addplate/addplate.component"
import { PlateDetailComponent } from "./components/platedetail/platedetail.component"
import {AddPlatePatternComponent} from "./components/addplatepattern/addplatepattern.component";
//import { AddPatternComponent } from "./components/addpattern/addpattern.component"
//import { AddPlatePatternComponent } from "./components/addplatepattern/addplaterpattern.component";

import { UppercaseDirective } from "./directives/uppercase.directive";

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        //FetchEmployeeComponent,
        //createemployee,
        PlateListComponent,
        AddPlateComponent,
        PlateDetailComponent,
        AddPlatePatternComponent,
        UppercaseDirective
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            //{ path: 'fetch-employee', component: FetchEmployeeComponent },
            //{ path: 'register-employee', component: createemployee },
            //{ path: 'employee/edit/:id', component: createemployee },
            { path: 'plate-list', component: PlateListComponent },
            { path: 'addplate', component: AddPlateComponent },
            { path: 'plate/patterns/:id', component: PlateDetailComponent },
            //{ path: 'patterns/:id/:patternId', component: AddPatternComponent },
            { path: 'patterns/:id/:patternId', component: AddPlatePatternComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    exports: [
        UppercaseDirective
    ],
    providers: [
        EmployeeService,
        PlateService
    ]
})
export class AppModuleShared {
}
