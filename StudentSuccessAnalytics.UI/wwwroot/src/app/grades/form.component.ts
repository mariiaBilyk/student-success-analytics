import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IdAndName } from '../common/models/id-and-name';
import { UniversityModulesService } from '../common/services/university-modules.service';

@Component({
    moduleId: module.id,
    selector: 'grades-filters-form',
    templateUrl: 'form.component.html',
    styleUrls: ['form.component.css'],
    providers: [UniversityModulesService]
})

export class FormComponent implements OnInit {
    departments: IdAndName[];
    department: number;

    teacher: number;
    teachers: IdAndName[];

    subject: number;
    subjects: IdAndName[];

    constructor( private _universityModulesService: UniversityModulesService ) {}

    getTeachers(){
        if (this.department > 0 )
            this._universityModulesService.getTeachers(this.department).then((teachers: IdAndName[] ) => 
                this.teachers = teachers);
        else { 
            this.teachers = [];
            this.teacher = 0;
        }
    }

    getDepartments() {
        this._universityModulesService.getDepartments().then((departments: IdAndName[]) => {
            this.departments = departments;
            this.department = this.departments[0].id;

            this.getTeachers();
        });
    }

    getSubjects(){
        if (this.teacher > 0)
            this._universityModulesService.getSubjects(this.teacher).then((subjects: IdAndName[]) => 
                this.subjects = subjects)
        else { 
            this.subjects = [];
            this.subject = 0;
        }
    }

    @Output() show = new EventEmitter<boolean>();

    ngOnInit() {
        this.getDepartments();
    }

    showChart() { 
        this.show.emit(true);
    }
}