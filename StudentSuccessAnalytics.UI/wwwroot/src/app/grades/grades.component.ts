import { Component } from '@angular/core';
import { GradesService } from '../common/services/grades.service';
import { GradesChartModel } from '../common/models/grades-chart-model';
import { FormComponent } from './form.component';
 
@Component({
  moduleId: module.id,
  selector: 'app-grades',

  templateUrl: './grades.component.html',

  styleUrls: ['./grades.component.css']
})
export class GradesComponent {
  public chartShown: boolean = true;
}  