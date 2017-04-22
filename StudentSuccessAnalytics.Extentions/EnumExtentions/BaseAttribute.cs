using System;

namespace StudentSuccessAnalytics.Extentions.EnumExtentions {
    public abstract class BaseAttribute : Attribute {
        private readonly object _value;

        public BaseAttribute ( object value ) {
            _value = value;
        }

        public object GetValue () {
            return _value;
        }
    }
}