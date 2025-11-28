using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace nonsense.WPF.Features.Common.Converters
{
    public class PowerPlanStatusToColorConverter : IValueConverter
    {
        private static readonly SolidColorBrush GreenBrush = new SolidColorBrush(Color.FromRgb(16, 213, 130));
        private static readonly SolidColorBrush RedBrush = new SolidColorBrush(Color.FromRgb(255, 71, 87));

        static PowerPlanStatusToColorConverter()
        {
            GreenBrush.Freeze();
            RedBrush.Freeze();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool existsOnSystem)
            {
                return existsOnSystem ? GreenBrush : RedBrush;
            }
            return RedBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
