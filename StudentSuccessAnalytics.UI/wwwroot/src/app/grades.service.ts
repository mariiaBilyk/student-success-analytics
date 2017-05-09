import { Injectable } from '@angular/core';
import { GradesChartItem } from './common/models/grades-chart-item';
import { GradesChartModel } from './common/models/grades-chart-model';

@Injectable()
export class GradesService {

  constructor() { }
  getGrades() {
    return new GradesChartModel ([
    		new GradesChartItem ("50", 20),
    		new GradesChartItem ("60", 30),
    		new GradesChartItem ("70", 35),
    		new GradesChartItem ("80", 25)
    	],
    	{});
	  }
}