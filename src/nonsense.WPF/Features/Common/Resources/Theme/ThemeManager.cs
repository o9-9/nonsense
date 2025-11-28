using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using nonsense.Core.Features.Common.Interfaces;
using nonsense.WPF.Properties;

namespace nonsense.WPF.Features.Common.Resources.Theme
{
    public partial class ThemeManager : ObservableObject, IThemeManager, IDisposable
    {
        private bool _isDarkTheme = true;

        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (_isDarkTheme != value)
                {
                    _isDarkTheme = value;
                    OnPropertyChanged(nameof(IsDarkTheme));
                    Application.Current.Resources["IsDarkTheme"] = _isDarkTheme;
                }
            }
        }

        private readonly INavigationService _navigationService;
        private readonly IWindowsThemeQueryService _windowsThemeQueryService;

        private static readonly Dictionary<string, Color> DarkThemeColors = new()
        {
            { "PrimaryTextColor", Color.FromRgb(245, 245, 247) },
            { "SecondaryTextColor", Color.FromRgb(184, 186, 189) },
            { "TertiaryTextColor", Color.FromRgb(110, 113, 117) },
            { "HelpIconColor", Color.FromRgb(245, 245, 247) },
            { "TooltipBackgroundColor", Color.FromRgb(21, 27, 51) },
            { "TooltipForegroundColor", Color.FromRgb(245, 245, 247) },
            { "TooltipBorderColor", Color.FromRgb(255, 107, 157) },
            { "ControlForegroundColor", Color.FromRgb(245, 245, 247) },
            { "ControlFillColor", Color.FromRgb(245, 245, 247) },
            { "ControlBorderColor", Color.FromRgb(255, 107, 157) },
            { "ToggleKnobColor", Color.FromRgb(232, 233, 234) },
            { "ToggleKnobCheckedColor", Color.FromRgb(10, 14, 39) },
            { "ContentSectionBorderColor", Color.FromRgb(31, 37, 68) },
            { "MainContainerBorderColor", Color.FromRgb(31, 37, 68) },
            { "SettingsItemBackgroundColor", Color.FromRgb(21, 27, 51) },
            { "PrimaryButtonForegroundColor", Color.FromRgb(245, 245, 247) },
            { "AccentColor", Color.FromRgb(255, 107, 157) },
            { "ButtonHoverTextColor", Color.FromRgb(10, 14, 39) },
            { "ButtonDisabledForegroundColor", Color.FromRgb(110, 113, 117) },
            { "ButtonDisabledBorderColor", Color.FromRgb(31, 37, 68) },
            { "NavigationButtonBackgroundColor", Color.FromRgb(21, 27, 51) },
            { "NavigationButtonForegroundColor", Color.FromRgb(245, 245, 247) },
            { "SliderTrackColor", Color.FromRgb(31, 37, 68) },
            { "BackgroundColor", Color.FromRgb(10, 14, 39) },
            { "ContentSectionBackgroundColor", Color.FromRgb(21, 27, 51) },
            { "ElevatedBackgroundColor", Color.FromRgb(31, 37, 68) },
            { "ScrollBarThumbColor", Color.FromRgb(255, 107, 157) },
            { "ScrollBarThumbHoverColor", Color.FromRgb(255, 139, 177) },
            { "ScrollBarThumbPressedColor", Color.FromRgb(0, 217, 255) },
        };

        private static readonly Dictionary<string, Color> LightThemeColors = new()
        {
            { "PrimaryTextColor", Color.FromRgb(26, 29, 30) },
            { "SecondaryTextColor", Color.FromRgb(74, 78, 81) },
            { "TertiaryTextColor", Color.FromRgb(139, 145, 151) },
            { "HelpIconColor", Color.FromRgb(26, 29, 30) },
            { "TooltipBackgroundColor", Color.FromRgb(255, 255, 255) },
            { "TooltipForegroundColor", Color.FromRgb(26, 29, 30) },
            { "TooltipBorderColor", Color.FromRgb(0, 109, 119) },
            { "ControlForegroundColor", Color.FromRgb(26, 29, 30) },
            { "ControlFillColor", Color.FromRgb(26, 29, 30) },
            { "ControlBorderColor", Color.FromRgb(0, 109, 119) },
            { "ToggleKnobColor", Color.FromRgb(74, 78, 81) },
            { "ToggleKnobCheckedColor", Color.FromRgb(248, 249, 250) },
            { "ContentSectionBorderColor", Color.FromRgb(227, 232, 239) },
            { "MainContainerBorderColor", Color.FromRgb(248, 249, 250) },
            { "SettingsItemBackgroundColor", Color.FromRgb(255, 255, 255) },
            { "PrimaryButtonForegroundColor", Color.FromRgb(26, 29, 30) },
            { "AccentColor", Color.FromRgb(0, 109, 119) },
            { "ButtonHoverTextColor", Color.FromRgb(255, 255, 255) },
            { "ButtonDisabledForegroundColor", Color.FromRgb(181, 185, 189) },
            { "ButtonDisabledBorderColor", Color.FromRgb(227, 232, 239) },
            { "NavigationButtonBackgroundColor", Color.FromRgb(240, 243, 247) },
            { "NavigationButtonForegroundColor", Color.FromRgb(26, 29, 30) },
            { "SliderTrackColor", Color.FromRgb(227, 232, 239) },
            { "BackgroundColor", Color.FromRgb(248, 249, 250) },
            { "ContentSectionBackgroundColor", Color.FromRgb(255, 255, 255) },
            { "ElevatedBackgroundColor", Color.FromRgb(240, 243, 247) },
            { "ScrollBarThumbColor", Color.FromRgb(0, 109, 119) },
            { "ScrollBarThumbHoverColor", Color.FromRgb(114, 9, 183) },
            { "ScrollBarThumbPressedColor", Color.FromRgb(86, 11, 173) },
        };

        public ThemeManager(INavigationService navigationService, IWindowsThemeQueryService windowsThemeQueryService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _windowsThemeQueryService = windowsThemeQueryService ?? throw new ArgumentNullException(nameof(windowsThemeQueryService));

            LoadThemePreference();
            ApplyTheme();
        }

        public void ToggleTheme()
        {
            IsDarkTheme = !IsDarkTheme;
            ApplyTheme();
            SaveThemePreference();
        }

        public void ApplyTheme()
        {
            try
            {
                var themeColors = IsDarkTheme ? DarkThemeColors : LightThemeColors;

                var brushes = new List<(string key, SolidColorBrush brush)>
                {
                    ("WindowBackground", new SolidColorBrush(themeColors["BackgroundColor"])),
                    ("PrimaryTextColor", new SolidColorBrush(themeColors["PrimaryTextColor"])),
                    ("SecondaryTextColor", new SolidColorBrush(themeColors["SecondaryTextColor"])),
                    ("TertiaryTextColor", new SolidColorBrush(themeColors["TertiaryTextColor"])),
                    ("SubTextColor", new SolidColorBrush(themeColors["SecondaryTextColor"])),
                    ("HelpIconForeground", new SolidColorBrush(themeColors["HelpIconColor"])),
                    ("ContentSectionBackground", new SolidColorBrush(themeColors["ContentSectionBackgroundColor"])),
                    ("ElevatedBackground", new SolidColorBrush(themeColors["ElevatedBackgroundColor"])),
                    ("ContentSectionBorderBrush", new SolidColorBrush(themeColors["ContentSectionBorderColor"])),
                    ("MainContainerBorderBrush", new SolidColorBrush(themeColors["MainContainerBorderColor"])),
                    ("SettingsItemBackground", new SolidColorBrush(themeColors["SettingsItemBackgroundColor"])),
                    ("NavigationButtonBackground", new SolidColorBrush(themeColors["NavigationButtonBackgroundColor"])),
                    ("NavigationButtonForeground", new SolidColorBrush(themeColors["NavigationButtonForegroundColor"])),
                    ("ButtonBorderBrush", new SolidColorBrush(themeColors["AccentColor"])),
                    ("ButtonHoverBackground", new SolidColorBrush(themeColors["AccentColor"])),
                    ("ButtonHoverTextColor", new SolidColorBrush(themeColors["ButtonHoverTextColor"])),
                    ("PrimaryButtonForeground", new SolidColorBrush(themeColors["PrimaryButtonForegroundColor"])),
                    ("ButtonDisabledForeground", new SolidColorBrush(themeColors["ButtonDisabledForegroundColor"])),
                    ("ButtonDisabledBorderBrush", new SolidColorBrush(themeColors["ButtonDisabledBorderColor"])),
                    ("ButtonDisabledHoverBackground", new SolidColorBrush(themeColors["ButtonDisabledBorderColor"])),
                    ("ButtonDisabledHoverForeground", new SolidColorBrush(themeColors["ButtonDisabledForegroundColor"])),
                    ("TooltipBackground", new SolidColorBrush(themeColors["TooltipBackgroundColor"])),
                    ("TooltipForeground", new SolidColorBrush(themeColors["TooltipForegroundColor"])),
                    ("TooltipBorderBrush", new SolidColorBrush(themeColors["TooltipBorderColor"])),
                    ("ControlForeground", new SolidColorBrush(themeColors["ControlForegroundColor"])),
                    ("ControlFillColor", new SolidColorBrush(themeColors["ControlFillColor"])),
                    ("ControlBorderBrush", new SolidColorBrush(themeColors["ControlBorderColor"])),
                    ("ToggleKnobBrush", new SolidColorBrush(themeColors["ToggleKnobColor"])),
                    ("ToggleKnobCheckedBrush", new SolidColorBrush(themeColors["ToggleKnobCheckedColor"])),
                    ("SliderTrackBackground", new SolidColorBrush(themeColors["SliderTrackColor"])),
                    ("SliderAccentColor", new SolidColorBrush(IsDarkTheme ? themeColors["AccentColor"] : Color.FromRgb(240, 240, 240))),
                    ("TickBarForeground", new SolidColorBrush(themeColors["PrimaryTextColor"])),
                    ("ScrollBarThumbBrush", new SolidColorBrush(themeColors["ScrollBarThumbColor"])),
                    ("ScrollBarThumbHoverBrush", new SolidColorBrush(themeColors["ScrollBarThumbHoverColor"])),
                    ("ScrollBarThumbPressedBrush", new SolidColorBrush(themeColors["ScrollBarThumbPressedColor"])),
                };

                foreach (var (key, brush) in brushes)
                {
                    brush.Freeze();
                }

                var resources = Application.Current.Resources;

                resources.BeginInit();
                try
                {
                    foreach (var (key, brush) in brushes)
                    {
                        resources[key] = brush;
                    }
                }
                finally
                {
                    resources.EndInit();
                }

                Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    NotifyWindowsOfThemeChange();
                }, System.Windows.Threading.DispatcherPriority.Background);
            }
            catch (Exception ex)
            {
            }
        }

        private void SaveThemePreference()
        {
            try
            {
                Settings.Default.ThemeSetByUser = true;
                Settings.Default.IsDarkTheme = IsDarkTheme;
                Settings.Default.Save();
            }
            catch
            {
            }
        }

        public void LoadThemePreference()
        {
            try
            {
                if (!Settings.Default.ThemeSetByUser)
                {
                    IsDarkTheme = _windowsThemeQueryService.IsDarkModeEnabled();
                }
                else
                {
                    IsDarkTheme = Settings.Default.IsDarkTheme;
                }
            }
            catch
            {
                IsDarkTheme = true;
            }
        }

        public void Dispose()
        {
        }

        public void ResetThemePreference()
        {
            try
            {
                Settings.Default.Reset();
                LoadThemePreference();
                ApplyTheme();
            }
            catch
            {
            }
        }

        private void NotifyWindowsOfThemeChange()
        {
            try
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is nonsense.WPF.Features.Common.Interfaces.IThemeAwareWindow themeAware)
                    {
                        window.Dispatcher.Invoke(() => themeAware.OnThemeChanged(IsDarkTheme));
                    }
                }
            }
            catch
            {
            }
        }
    }
}
