import { Injectable } from '@angular/core';
import { GradesChartItem } from '../models/grades-chart-item';
import { GradesChartModel } from '../models/grades-chart-model';
import * as _ from "lodash";
import { SEMESTER_GRADES } from '../data/semester-grades';
import { STUDENT_SUCCESS } from '../data/student-success'

@Injectable()
export class GradesService {
  constructor() { }
  getGrades() {
    let grades = _.first(STUDENT_SUCCESS);

      return grades ? grades.grades : [];
	  }

  getSemesterGrades(instituteId:number, specializationId:number, academYear:number, semester:number) {
      let grades = _.first(_.filter(SEMESTER_GRADES, { 
          'instituteId': instituteId, 
          'specializationId': specializationId,
          'academYear': academYear,
          'semester': semester
      }));
      console.log(instituteId + " " + academYear);

      return grades ? grades.grades : [];
  }

  getStudentsSuccess(instituteId:number, specializationId:number, threadId: number){
      let grades = _.first(_.filter(STUDENT_SUCCESS,{
          'instituteId': instituteId, 
          'specializationId': specializationId,
          'threadId': threadId
      }));

      return grades ? grades.grades : [];
  }
}