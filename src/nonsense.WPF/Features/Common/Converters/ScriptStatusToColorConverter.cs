using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace nonsense.WPF.Features.Common.Converters
{
    public class ScriptStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isActive)
            {
                // Return green if scripts are active, gray if not
                return isActive
                    ? new SolidColorBrush(Color.FromRgb(16, 213, 130)) // Green for active
                    : new SolidColorBrush(Color.FromRgb(139, 145, 151)); // Gray for inactive
            }

            return new SolidColorBrush(Color.FromRgb(139, 145, 151));
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture
        )
        {
            throw new NotImplementedException();
        }
    }
}
