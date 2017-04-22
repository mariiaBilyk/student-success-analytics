using StudentSuccessAnalytics.Domain.Models.Common;
using StudentSuccessAnalytics.Domain.Models.Enums;

namespace StudentSuccessAnalytics.Domain.Models.Grades {
    public class Subject : BaseEntity {
        public string SubjectName { get; set; }
        public ControlTypes ControlType { get; set; }
        public int Semester { get; set; }
        public int TotalMark { get; set; }
        public int Coeficient { get; set; }
    }
}