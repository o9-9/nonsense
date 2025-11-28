using System.Windows;
using nonsense.WPF.Features.Common.ViewModels;

namespace nonsense.WPF.Features.Common.Views
{
    public partial class ConfigImportOverlayWindow : Window
    {
        public ConfigImportOverlayViewModel ViewModel { get; }

        public ConfigImportOverlayWindow(string statusText)
        {
            InitializeComponent();
            ViewModel = new ConfigImportOverlayViewModel { StatusText = statusText };
            DataContext = ViewModel;
        }

        public void UpdateProgress(string detailText)
        {
            Dispatcher.Invoke(() =>
            {
                ViewModel.DetailText = detailText;
            });
        }
    }
}
