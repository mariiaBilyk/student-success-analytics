import { Component } from '@angular/core';
import { GradesService } from '../common/services/grades.service';
import { GradesChartModel } from '../common/models/grades-chart-model';
 
@Component({
  moduleId: module.id,
  selector: 'chart',

  templateUrl: './chart.component.html',

  styleUrls: ['./chart.component.css']
})
export class ChartComponent {

  constructor ( private _gradesService: GradesService ) {};

  public chartShown: boolean = false;

  public barChartOptions:any = {
    scaleShowVerticalLines: false,
    responsive: true
  };
  public barChartLabels:string[] = [];
  public barChartType:string = 'bar';
  public barChartLegend:boolean = true;

  public GradesChartData: GradesChartModel;
 
  public barChartData:any[] = [];

  ngOnInit() {
      this.getChartData();
  }
 
  // events
  public chartClicked(e:any):void {
    console.log(e);
  }
 
  public chartHovered(e:any):void {
    console.log(e);
  }
 
  public randomize():void {
    // Only Change 3 values
    let data = [
      Math.round(Math.random() * 100),
      59,
      80,
      (Math.random() * 100),
      56,
      (Math.random() * 100),
      40];
    let clone = JSON.parse(JSON.stringify(this.barChartData));
    clone[0].data = data;
    this.barChartData = clone;
    /**
     * (My guess), for Angular to recognize the change in the dataset
     * it has to change the dataset variable directly,
     * so one way around it, is to clone the data, change it and then
     * assign it;
     */
  }

  private getChartData(){
    this.GradesChartData = this._gradesService.getGrades();

    this.barChartLabels = this.GradesChartData.chartData.map( x => x.grade );
    this.barChartData.push(
      {
        data: this.GradesChartData.chartData.map( x => x.count ), 
        label: "Grades"
      });
  }
}