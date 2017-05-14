import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IdAndName } from '../common/models/id-and-name';
import { Specialization } from '../common/models/specialization';
import { UniversityModulesService } from '../common/services/university-modules.service';
import * as _ from "lodash";

@Component({
    moduleId: module.id,
    selector: 'budget-filters-form',
    templateUrl: 'budget-form.component.html',
    styleUrls: ['budget.component.css'],
    providers: [UniversityModulesService]
})

export class BudgetFormComponent implements OnInit {
    institutes: IdAndName[];
    institute: number;

    specialization: number;
    specializations: Specialization[];

    constructor( private _universityModulesService: UniversityModulesService ) {}

    getInstitutes(){
        this._universityModulesService.getInstitutes().then((institutes: IdAndName[] ) => {
            this.institutes = institutes;
            this.institute = this.institutes[0].id;

            this.getSpecializations();
        });
    }

    getSpecializations() {
        if (this.institute > 0)
            this._universityModulesService.getSpecializations(this.institute)
                .then((specializations: Specialization[], ) => {
                    this.specializations = specializations;
                });
        else {
            this.specializations = [];
            this.specialization = 0;
        }
    }

    @Output() show = new EventEmitter<boolean>();

    ngOnInit() {
        this.getInstitutes();
    }

    showChart() { 
        this.show.emit(true);
    }
}