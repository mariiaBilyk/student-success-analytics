using StudentSuccessAnalytics.Domain.Models.Common;
using StudentSuccessAnalytics.Domain.Models.Enums;

namespace StudentSuccessAnalytics.Domain.Models.Grades {
    public class Grade : BaseEntity {
        public string SubjectName { get; set; }
        public ControlTypes ControlType { get; set; }
        public int Semester { get; set; }
        public int TotalMark { get; set; }
        public int Coeficient { get; set; }
        public bool RepeatStuding { get; set; }
        public int TeacherId { get; set; }
        public int DepartmentId { get; set; }
        public int StudentId { get; set; }
    }
}