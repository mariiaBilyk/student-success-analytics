import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IdAndName } from '../common/models/id-and-name';
import { Specialization } from '../common/models/specialization';
import { UniversityModulesService } from '../common/services/university-modules.service';
import * as _ from "lodash";

@Component({
    moduleId: module.id,
    selector: 'student-sucess-filters-form',
    templateUrl: 'student-sucess-form.component.html',
    styleUrls: ['student-sucess.component.css'],
    providers: [UniversityModulesService]
})

export class SemesterSucessFormComponent implements OnInit {
    institutes: IdAndName[];
    institute: number;

    specialization: number;
    specializations: Specialization[];

    stream: number;
    streams: IdAndName[];

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

    getStreams() {
        if (this.specialization > 0){
            this._universityModulesService.getStreams(this.specialization)
                .then(( streams: IdAndName[] ) => {
                    this.streams = streams;
                });
        }
    }

    @Output() show = new EventEmitter<boolean>();

    ngOnInit() {
        this.getInstitutes();
    }

    showChart() { 
        this.show.emit(true);
        console.log('click');
    }
}