using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace nonsense.WPF.Converters
{
    public class BooleanToReinstallableColorConverter : IValueConverter
    {
        private static readonly SolidColorBrush BlueBrush = new SolidColorBrush(Color.FromRgb(0, 217, 255));
        private static readonly SolidColorBrush RedBrush = new SolidColorBrush(Color.FromRgb(255, 71, 87));
        private static readonly SolidColorBrush GrayBrush = new SolidColorBrush(Color.FromRgb(139, 145, 151));

        static BooleanToReinstallableColorConverter()
        {
            BlueBrush.Freeze();
            RedBrush.Freeze();
            GrayBrush.Freeze();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool canBeReinstalled)
            {
                return canBeReinstalled ? BlueBrush : RedBrush;
            }
            return GrayBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}