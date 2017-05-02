using System.Collections.Generic;
using StudentSuccess.WebAPI.Models.GradesChart;
using StudentSuccess.WebAPI.Services.Common;
using StudentSuccessAnalytics.Infrastructure.Common;

namespace StudentSuccess.WebAPI.Services {
    public class GradesAnalyticsService : ServiceBase {
        public GradesAnalyticsService ( IUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }

        public GradesChartBindingModel GetGradesChart ( GradesChartFiltersBindingModel filtering ) {
            return new GradesChartBindingModel {
                ChartItems = new List<GradeChartItem>() {
                    new GradeChartItem {Grade = 100, Count = 1},
                    new GradeChartItem {Grade = 90, Count = 3},
                    new GradeChartItem {Grade = 80, Count = 5},
                    new GradeChartItem {Grade = 70, Count = 10},
                    new GradeChartItem {Grade = 60, Count = 5},
                    new GradeChartItem {Grade = 50, Count = 3}
                }
            };
        }

        public GradesChartBindingModel GetGradesChart ( SpecGradesFiltersBindingModel filtering ) {
            return new GradesChartBindingModel {
                ChartItems = new List<GradeChartItem>() {
                    new GradeChartItem {Grade = 100, Count = 1},
                    new GradeChartItem {Grade = 90, Count = 3},
                    new GradeChartItem {Grade = 80, Count = 5},
                    new GradeChartItem {Grade = 70, Count = 10},
                    new GradeChartItem {Grade = 60, Count = 5},
                    new GradeChartItem {Grade = 50, Count = 3}
                }
            };
        }

        public GradesChartBindingModel GetGradesChart ( TeacherGradesFiltersBindingModel filtering ) {
            return new GradesChartBindingModel {
                ChartItems = new List<GradeChartItem>() {
                    new GradeChartItem {Grade = 100, Count = 1},
                    new GradeChartItem {Grade = 90, Count = 3},
                    new GradeChartItem {Grade = 80, Count = 5},
                    new GradeChartItem {Grade = 70, Count = 10},
                    new GradeChartItem {Grade = 60, Count = 5},
                    new GradeChartItem {Grade = 50, Count = 3}
                }
            };
        }
    }
}