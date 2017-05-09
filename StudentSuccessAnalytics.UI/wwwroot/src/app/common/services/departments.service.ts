import { Injectable } from "@angular/core";
import { Headers, Http } from '@angular/http';
import { IdAndName } from '../models/id-and-name';

import 'rxjs/add/operator/toPromise';
import {TEACHERS} from "../models/teacher.data";


@Injectable()

export class DepartmentsService {
    private departmentsEndpoint = "http://localhost:51113/api/department";

    constructor(private http: Http) { }

    getDepartments() {
        return this.http.get(this.departmentsEndpoint + "?instituteId=4")
            .toPromise()
            .then(response => response.json().data as IdAndName[])
            .catch(this.handleError)
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); 
        return Promise.reject(error.message || error);
    }
}