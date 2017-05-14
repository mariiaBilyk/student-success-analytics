using StudentSuccessAnalytics.Domain.Models.Common;
using StudentSuccessAnalytics.Domain.Models.Enums;

namespace StudentSuccessAnalytics.Domain.Models.Grades {
    public class Subject : BaseEntity {
        public string Name { get; set; }
        public ControlTypes TypeControl { get; set; }
        public int EctsCredits { get; set; }
    }
}