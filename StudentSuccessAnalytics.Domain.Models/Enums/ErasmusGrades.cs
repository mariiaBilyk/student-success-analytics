using StudentSuccessAnalytics.Extentions.EnumExtentions;

namespace StudentSuccessAnalytics.Domain.Models.Enums {
    public enum ErasmusGrades {
        [MaxGrade(100)]
        [MinGrade(88)]
        A,

        [MaxGrade(87)]
        [MinGrade(80)]
        B,

        [MaxGrade(79)]
        [MinGrade(71)]
        C,

        [MaxGrade(70)]
        [MinGrade(61)]
        D,

        [MaxGrade(60)]
        [MinGrade(50)]
        E,

        [MaxGrade(49)]
        F
    }
}