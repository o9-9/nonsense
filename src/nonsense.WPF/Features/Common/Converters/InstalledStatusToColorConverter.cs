using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace nonsense.WPF.Converters;

public class InstalledStatusToColorConverter : IValueConverter
{
    private static readonly SolidColorBrush GreenBrush = new SolidColorBrush(Color.FromRgb(16, 213, 130));
    private static readonly SolidColorBrush RedBrush = new SolidColorBrush(Color.FromRgb(255, 71, 87));
    private static readonly SolidColorBrush GrayBrush = new SolidColorBrush(Color.FromRgb(139, 145, 151));

    static InstalledStatusToColorConverter()
    {
        GreenBrush.Freeze();
        RedBrush.Freeze();
        GrayBrush.Freeze();
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isInstalled)
        {
            return isInstalled ? GreenBrush : RedBrush;
        }
        return GrayBrush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}