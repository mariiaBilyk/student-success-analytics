import { Injectable } from '@angular/core';
import { GradesChartItem } from '../models/grades-chart-item';
import { GradesChartModel } from '../models/grades-chart-model';
@Injectable()
export class GradesService {
  constructor() { }
  getGrades() {
    return new GradesChartModel ([
    		new GradesChartItem ("50", "denna", 30, 2016),
    		new GradesChartItem ("50",  "denna", 20, 2017),
    		new GradesChartItem ("70",  "denna", 10, 2017),
    		new GradesChartItem ("80",  "nedenna", 23 ,2017),
        new GradesChartItem ("50", "denna", 30, 2018),
        new GradesChartItem ("50",  "denna", 20, 2019),
        new GradesChartItem ("70",  "denna", 10, 2018),
        new GradesChartItem ("70",  "nedenna", 23 ,2019)
    	],
    	{});
	  }
}