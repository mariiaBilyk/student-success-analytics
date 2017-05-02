using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentSuccess.WebAPI.Models.GradesChart {
    public class GradesChartFiltersBaseBindingModel {
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DefaultValue(1)]
        public int StudyForm { get; set; }

        [DefaultValue(1)]
        public int StudyQualification { get; set; } 
    }

    public class GradesChartFiltersBindingModel : GradesChartFiltersBaseBindingModel {
        public IEnumerable<int> InstitutesIds { get; set; } 
    }

    public class SpecGradesFiltersBindingModel : GradesChartFiltersBaseBindingModel {
        public int SpecializationId { get; set; }
        public int StudyYear { get; set; }  
    }

    public class TeacherGradesFiltersBindingModel : GradesChartFiltersBaseBindingModel {
        [Required]
        public int IstituteId { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public int DisciplineId { get; set; }   
    }
}