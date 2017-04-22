using System;
using System.Collections.Generic;

namespace StudentSuccess.WebAPI.Models.GradesChart {
    public class GradesChartFiltersBaseBindingModel {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class GradesChartFiltersBindingModel : GradesChartFiltersBaseBindingModel {
        public IEnumerable<int> InstitutesIds { get; set; } 
    }

    public class SpecGradesFiltersBindingModel : GradesChartFiltersBaseBindingModel {
        public int SpecializationId { get; set; }
        public int StudyYear { get; set; }  
    }

    public class TeacherGradesFiltersBindingModel : GradesChartFiltersBaseBindingModel {
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public int DisciplineId { get; set; }   
    }
}