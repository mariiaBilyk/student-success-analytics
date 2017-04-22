using StudentSuccessAnalytics.Domain.Models.Common;

namespace StudentSuccessAnalytics.Domain.Models.UniversityModules {
    public class Institute : BaseEntity {
        public string ShortTitle { get; set; }
        public string Title { get; set; }   
    }
}