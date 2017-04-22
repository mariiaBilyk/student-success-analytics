using System.Collections.Generic;

namespace StudentSuccess.WebAPI.Models.GradesChart {
    public class GradesChartBindingModel {
        public IEnumerable<GradeChartItem> ChartItems { get; set; } 
    }

    public class GradeChartItem {
        public int Grade { get; set; }
        public int Count { get; set; }  
    }
}