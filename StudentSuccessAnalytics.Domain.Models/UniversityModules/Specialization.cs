using StudentSuccessAnalytics.Domain.Models.Common;

namespace StudentSuccessAnalytics.Domain.Models.UniversityModules {
    public class Specialization : BaseEntity {
        public string Code { get; set; }
        public string Title { get; set; }
    }
}