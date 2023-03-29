using System;
using System.Windows.Markup;

namespace WPFApp.View
{
    public class EnumBindingExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingExtension(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
                throw new Exception("Enum must not be null and of type Enum.");

            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
