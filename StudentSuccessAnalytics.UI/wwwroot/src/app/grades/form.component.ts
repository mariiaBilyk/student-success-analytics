import { Component, OnInit } from '@angular/core';
import { IdAndName } from '../common/models/id-and-name';
import { TeacherService } from '../common/services/teachers.service';
import { DepartmentsService } from '../common/services/departments.service';

@Component({
    moduleId: module.id,
    selector: 'grades-filters-form',
    templateUrl: 'form.component.html',
    styleUrls: ['form.component.css'],
    providers: [TeacherService]
})

export class FormComponent implements OnInit {
    departments: IdAndName[];
    department: number;

    teacher: number;
    teachers: IdAndName[];

    subject: string;
    subjects: string[] = ["John", "Paul", "George", "Ringo"];

    constructor( private _teacherService: TeacherService, private _departmentsService: DepartmentsService ) {}

    getTeachers(){
        this._teacherService.getTeachers().then((teachers: IdAndName[] ) => this.teachers = teachers);
    }

    getDepartments() {
        this._departmentsService.getDepartments().then((departments: IdAndName[]) => this.departments = departments);
        this.department = this.departments[0].id;
    }

    ngOnInit() {
        this.getDepartments();
    }

    alert() { console.log(this.department); }
}