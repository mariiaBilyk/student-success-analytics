import { Injectable } from "@angular/core";
import { Headers, Http } from '@angular/http';
import { IdAndName } from '../models/id-and-name';

import 'rxjs/add/operator/toPromise';
import {TEACHERS, DEPARTMENTS, SUBJECTS, INSTITUTES, SPECIALIZATIONS, STREAMS } from "../models/teacher.data";


@Injectable()

export class UniversityModulesService {
    private departmentsEndpoint = "http://localhost:51113/api/department";

    constructor(private http: Http) { }

    getDepartments() {
        // return this.http.get(this.departmentsEndpoint + "?instituteId=4")
        //     .toPromise()
        //     .then(response => response.json().data as IdAndName[])
        //     .catch(this.handleError)
        return Promise.resolve(DEPARTMENTS);
    }

    getTeachers( departmentId: number){
        return Promise.resolve(TEACHERS);
    }

    getSubjects(teacherId: number){
        return Promise.resolve(SUBJECTS);
    }

    getInstitutes(){
        return Promise.resolve(INSTITUTES);
    }

    getSpecializations(instituteId: number){
        return Promise.resolve(SPECIALIZATIONS);
    }

    getStreams(specializationId: number){
        return Promise.resolve(STREAMS);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }
}