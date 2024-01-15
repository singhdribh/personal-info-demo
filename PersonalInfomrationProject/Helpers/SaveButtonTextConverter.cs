using System;
using System.Globalization;
using System.Windows.Data;

namespace PersonalInfomrationProject.Helpers
{
    public class SaveButtonTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string val)
            {
                if (!string.IsNullOrEmpty(val))
                {
                    return "Update";
                }
            }
            return "Save";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
