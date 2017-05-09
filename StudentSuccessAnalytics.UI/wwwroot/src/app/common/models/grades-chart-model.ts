import { GradesChartItem } from './grades-chart-item';

export class GradesChartModel {
	constructor( public chartData: GradesChartItem[], public filters: object ) {};
}