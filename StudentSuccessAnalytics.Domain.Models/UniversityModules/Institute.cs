using StudentSuccessAnalytics.Domain.Models.Common;

namespace StudentSuccessAnalytics.Domain.Models.UniversityModules {
    public class Institute : BaseEntity {
        public string ShortName { get; set; }
        public string Name { get; set; }   
    }
}