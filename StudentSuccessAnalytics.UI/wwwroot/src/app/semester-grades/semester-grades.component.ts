import {Component, OnInit} from '@angular/core';
import { GoogleChart } from 'angular2-google-chart/directives/angular2-google-chart.directive';
import { SemesterGradesFormComponent } from './semester-grades-form.component';
import { SemesterGradesChartComponent } from './semester-grades-chart.component';

@Component({
    selector: 'app-semester-grades',
    templateUrl: './semester-grades.component.html',
    styleUrls: ['./semester-grades.component.css']
})
export class SemesterGradesComponent implements OnInit {
    ngOnInit() {}
}
