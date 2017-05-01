using StudentSuccessAnalytics.Infrastructure.Repositories;

namespace StudentSuccessAnalitycs.Infrastructure.Sql.Repositories {
    public class GradeRepository : IGradeRepository {
        public string Id { get; }
        public string SubjectId { get; }
        public string TypeControl { get; }
        public string EctsCredits { get; }
        public string Semester { get; }
        public string TotalMark { get; }
        public string K { get; }
        public string RepeatStuding { get; }
        public string TeacherFullName { get; }
        public string DepartmentId { get; }
        public string StudentId { get; }
    }
}