import { Component, Input, OnInit } from '@angular/core';
import { GradesService } from '../common/services/grades.service';
import { GradesChartModel } from '../common/models/grades-chart-model';
import { GradesChartItem } from '../common/models/grades-chart-item';

 
@Component({
  moduleId: module.id,
  selector: 'budget-chart',

  templateUrl: './budget-chart.component.html',

  styleUrls: ['./budget.component.css']
})
export class BudgetChartComponent implements OnInit {

  constructor ( private _gradesService: GradesService ) {};

  @Input() showMe: boolean = false;

//  public col_ChartData = [];
    public col_ChartData = [
        ['', 'Кількість'],
        ['Повторне вивчення', 30],
        ['Стипендія', 150],
        ['Підвищена стипендія', 16],
    ]
  public col_ChartOptions = {
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
        seriesType: 'bars'
    };

  // private getChartData(){
  //  this.col_ChartData = (this._gradesService.getGrades().chartData.map(x => [x.grade, x.count]));
  //  this.col_ChartData.unshift(['Оцінка', 'Кількість']);
   
  // }
  //   this.barChartLabels = this.GradesChartData.chartData.map( x => x.grade );
  //   this.barChartData.push(
  //     {
  //       data: this.GradesChartData.chartData.map( x => x.count ), 
  //       label: "Grades"
  //     });
  // }
  ngOnInit() {}
}