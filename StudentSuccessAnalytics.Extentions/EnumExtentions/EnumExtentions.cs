using System;

namespace StudentSuccessAnalytics.Extentions.EnumExtentions {
    public static class EnumExtentionMethods {
        public static string GetMaxGrade ( this Enum enumItem ) {
            return enumItem.GetAttributeValue(typeof(MaxGrade), string.Empty);
        }

        public static string GetMicGrade ( this Enum enumItem ) {
            return enumItem.GetAttributeValue(typeof(MinGrade), string.Empty);
        }
    }
}