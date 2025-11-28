using System.Windows;
using System.Windows.Media;

namespace nonsense.WPF.Features.Common.Extensions
{
    public static class VisualTreeExtensions
    {
        public static T? FindVisualParent<T>(this DependencyObject child) where T : DependencyObject
        {
            var parentObject = VisualTreeHelper.GetParent(child);
            
            if (parentObject == null) 
                return null;
            
            if (parentObject is T parent)
                return parent;

            return FindVisualParent<T>(parentObject);
        }
    }
}