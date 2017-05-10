import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IdAndName } from '../common/models/id-and-name';
import { Specialization } from '../common/models/specialization';
import { UniversityModulesService } from '../common/services/university-modules.service';
import * as _ from "lodash";

@Component({
    moduleId: module.id,
    selector: 'semester-grades-filters-form',
    templateUrl: 'semester-grades-form.component.html',
    styleUrls: ['semester-grades.component.css'],
    providers: [UniversityModulesService]
})

export class SemesterGradesFormComponent implements OnInit {
    institutes: IdAndName[];
    institute: number;

    specialization: number;
    specializations: Specialization[];

    semester: number;
    semesters: number[];

    academYear: number;
    academYears: IdAndName[];

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
        console.log('click');
    }

    updateSpecializationData(){
        if (this.specialization > 0){
            let specialization = _.first(_.filter(this.specializations, ["id", this.specialization]));
            this.getAcademYears(specialization.firstAcademYear);
            this.getSpecSemesters(specialization.semesters);
        }
    }

    private getAcademYears(firstYear: number){
        //this.academYears = [{ id: 2015, name: "2015/2016"}, { id: 2016, name: "2016/2017"}];
        this.academYears = _.map(_.range(firstYear+1,2017),function(year){
            return { id:year, name: year.toString()+ '/' + (year+1).toString() };
        });
    }

    private getSpecSemesters(semestersCount: number){
        this.semesters = _.range(1,semestersCount+1);
    }
}