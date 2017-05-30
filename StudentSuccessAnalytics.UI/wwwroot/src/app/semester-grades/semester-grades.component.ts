import { GoogleChart } from 'angular2-google-chart/directives/angular2-google-chart.directive';
//import { SemesterGradesFormComponent } from './semester-grades-form.component';
import { SemesterGradesChartComponent } from './semester-grades-chart.component';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IdAndName } from '../common/models/id-and-name';
import { Specialization } from '../common/models/specialization';
import { UniversityModulesService } from '../common/services/university-modules.service';
import { GradesService } from '../common/services/grades.service';
import * as _ from "lodash";

@Component({
    moduleId: module.id,
    selector: 'semester-grades',
    templateUrl: 'semester-grades.component.html',
    styleUrls: ['semester-grades.component.css'],
    providers: [UniversityModulesService]
})

export class SemesterGradesComponent implements OnInit {
    data: any[];

    institutes: IdAndName[];
    institute: number;

    specialization: number;
    specializations: Specialization[];

    semester: number;
    semesters: number[];

    academYear: number;
    academYears: IdAndName[];

    constructor( private _universityModulesService: UniversityModulesService,
                 private _gradesService: GradesService ) {}

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

    //@Output() show = new EventEmitter<boolean>();
    show = false;	
    ngOnInit() {
        this.getInstitutes();
    }

    showChart() { 
        this.show = true;
        this.data = this._gradesService.getSemesterGrades(this.institute, this.specialization,
        												  this.academYear,
        	                                              this.semester);
        this.data.unshift(['Предмети', '5', '4', '3', 'Повторне вивчення']);
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