import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IdAndName } from '../common/models/id-and-name';
import { Specialization } from '../common/models/specialization';
import { UniversityModulesService } from '../common/services/university-modules.service';
import { GradesService } from '../common/services/grades.service';
import * as _ from "lodash";

@Component({
  selector: 'app-student-sucess',
  templateUrl: './student-sucess.component.html',
  styleUrls: ['./student-sucess.component.css']
})
export class StudentSucessComponent implements OnInit {

  institutes: IdAndName[];
    institute: number;

    specialization: number;
    specializations: Specialization[];

    stream: number;
    streams: IdAndName[];
    data: any[]=[['Оцінка', 'Форма', 'Кількість', 'Рік'],['40', 'vfd', 30, 1990]];
    show = false;

    constructor( private _universityModulesService: UniversityModulesService,
                 private _gradesService: GradesService) {}

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

    
    ngOnInit() {
        this.getInstitutes();
    }

    showChart() { 
        this.show = true;

        this.data = this._gradesService.getStudentsSuccess(this.institute, this.specialization, this.stream)
        	.map(x => [x.grade, x.studyForm, x.count, x.assessment]);

        this.data.unshift(['Оцінка', 'Форма', 'Кількість', 'Рік']);
    }
}
