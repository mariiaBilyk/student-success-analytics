import { Component, Input, OnInit } from '@angular/core';
import { GradesService } from '../common/services/grades.service';
import { GradesChartModel } from '../common/models/grades-chart-model';
import { GradesChartItem } from '../common/models/grades-chart-item';
declare var google: any;
 
@Component({
  moduleId: module.id,
  selector: 'chart',

  templateUrl: './chart.component.html',

  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  constructor ( private _gradesService: GradesService ) {};
  public col_ChartData: any = [];
   
  private drawChart() {
      var data = google.visualization.arrayToDataTable(this.col_ChartData);
      var options = {
        chartArea: { width: '50%' },
        vAxis: {
            title: 'Кількість',
            minValue: 0,
            textStyle: {
                bold: true,
                fontSize: 12,
                color: 'red'
            },
            titleTextStyle: {
                bold: true,
                fontSize: 18,
                color: '#4d4d4d'
            }
        },
        hAxis: {
            title: 'Оцінки',
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

      var control = new google.visualization.ControlWrapper({
        controlType: 'CategoryFilter',
        containerId: 'control_div',
        dataTable: data,
        options: {
            filterColumnIndex: 1,
            ui: {
               format: {pattern: '0'}
            }

        }
      });

      var slider = new google.visualization.ControlWrapper({
        controlType: 'NumberRangeFilter',
        containerId: 'filter_div',
        dataTable: data,
        options: {
          filterColumnIndex: 3,
          ui: {
            format: {pattern: '0'}
          }
        }
      });
      slider.draw();
      control.draw();
      google.visualization.events.addListener(control, 'statechange', function () {
        var state = control.getState();
        var row = [];
        var view = new google.visualization.DataView(data);
        for (var i = 0; i < state.selectedValues.length; i++) {
          row.push.apply(row,data.getFilteredRows([{column: 1, value: state.selectedValues[i]}]));
        }
        view.setRows(row);

        drawChart(view);
      });
      google.visualization.events.addListener(slider, 'statechange', function () {

        var range = slider.getState();
        var view = new google.visualization.DataView(data);
        
        view.setRows(data.getFilteredRows([{
          column: 3,
          minValue: range.lowValue,
          maxValue: range.highValue
        }]));
        console.log(view);
        drawChart(view);
      });
      function drawChart(dataTable) {
        var groupData = google.visualization.data.group(
          dataTable,
          [0],
          [{'column': 2, 'aggregation': google.visualization.data.sum, 'type': 'number'}]
        );
        var chart = new google.visualization.ColumnChart(document.getElementById('columnchart_values'));
        chart.draw(groupData, options);
      }
      
  }

  @Input() showMee: boolean = false;
  
  private getChartData(){
   this.col_ChartData = (this._gradesService.getGrades().map(x => [x.grade,x.studyForm, x.count, x.assessment]));
   this.col_ChartData.unshift(['Оцінка', 'Форма', 'Кількість', 'Рік' ]);
   console.log(this);
  }

  ngOnInit() {
    this.getChartData();
    google.charts.load("current", {packages:['corechart', 'controls', 'linechart']});
    google.charts.setOnLoadCallback(this.drawChart.bind(this));
  }
}