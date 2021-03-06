import {Component, OnInit, Input} from '@angular/core';
import { GoogleChart } from 'angular2-google-chart/directives/angular2-google-chart.directive';
import { SemesterGradesFormComponent } from './semester-grades-form.component';

@Component({
    selector: 'semester-grades-chart',
    templateUrl: './semester-grades-chart.component.html',
    styleUrls: ['./semester-grades.component.css']
})
export class SemesterGradesChartComponent implements OnInit {
    @Input() showMe: boolean = true;

    @Input() bar_ChartData = [];

    public bar_ChartOptions = {
        chartArea: { width: '50%' },
        vAxis: {
            minValue: 0,
            textStyle: {
                bold: true,
                fontSize: 12,
                color: '#4d4d4d'
            },
            titleTextStyle: {
                bold: true,
                fontSize: 18,
                color: '#4d4d4d'
            }
        },
        hAxis: {
            textStyle: {
                fontSize: 14,
                bold: true,
                color: '#848484'
            },
            titleTextStyle: {
                fontSize: 14,
                bold: true,
                color: '#848484'
            }
        },
        isStacked: 'percent'
    };
    ngOnInit() {}
}
