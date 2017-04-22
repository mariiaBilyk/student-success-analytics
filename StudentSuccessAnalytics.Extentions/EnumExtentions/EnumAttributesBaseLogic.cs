using System;
using System.Linq;

namespace StudentSuccessAnalytics.Extentions.EnumExtentions {
    public static class EnumAttributesBaseLogic {
        /// <param name="enumItem">Enum element</param>
        /// <param name="attributeType">Attributes type, which value we need</param>
        /// <param name="defaultValue">
        ///     Default value, which will be passed,
        ///     if none value is selected for enum element
        /// </param>
        /// <returns>Attribute value for current enum element</returns>
        public static TVal GetAttributeValue<TEnum, TVal> ( this TEnum enumItem, Type attributeType, TVal defaultValue ) {
            var attribute = enumItem.GetType().GetField(enumItem.ToString())
                .GetCustomAttributes(attributeType, true)
                .OfType<BaseAttribute>()
                .FirstOrDefault();

            return attribute == null ? defaultValue : (TVal) attribute.GetValue();
        }

        public static TEnum GetValueFromAttribute<TEnum, TAttribute>
            ( string text, Func<TAttribute, string> valueFunc ) where TAttribute : BaseAttribute {
            var type = typeof(TEnum);

            if ( !type.IsEnum ) throw new InvalidOperationException();

            foreach ( var field in type.GetFields() ) {
                var attribute = Attribute.GetCustomAttribute(field, typeof(TAttribute)) as TAttribute;

                if ( attribute != null ) {
                    if ( valueFunc.Invoke(attribute) == text )
                        return (TEnum) field.GetValue(null);
                } else {
                    if ( field.Name == text )
                        return (TEnum) field.GetValue(null);
                }
            }
            return default(TEnum);
        }
    }
}