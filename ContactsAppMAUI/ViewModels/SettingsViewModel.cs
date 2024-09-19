using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using ContactsAppMAUI.Service;

namespace ContactsAppMAUI.ViewModels;

[ObservableObject]
public partial class SettingsViewModel
{
    public SettingsViewModel()
    {
        var defaultThemes = new List<Theme>()
        {
            new Theme("Same as system", "System"),
            new Theme("Dark", "Dark"),
            new Theme("Light", "Light"),
        };

        Themes = new List<Theme>(defaultThemes);

        var hasCustom = Preferences.ContainsKey("CustomTheme");

        if (hasCustom)
        {
            Themes.Add(new Theme("Custom theme", "Custom"));
        }

        var theme = Preferences.Get("theme", "System");

        SelectedTheme = Themes.Single(x => x.Key == theme);

        WeakReferenceMessenger.Default.Register<ThemeAddedMessage>(this, (r, m) =>
        {
            SelectedTheme = null;

            if (m.Value == "Custom")
            {
                var customTheme = Themes.SingleOrDefault(x => x.Key == "Custom");

                if (customTheme == null)
                {
                    customTheme = new Theme("Custom theme", "Custom");

                    Themes.Add(customTheme);
                }

                SelectedTheme = customTheme;
            }
        });
    }

    [ObservableProperty]
    private List<Theme> themes;

    [ObservableProperty]
    private Theme selectedTheme;

    partial void OnSelectedThemeChanged(Theme value)
    {
        if (value == null)
        {
            return;
        }

        Preferences.Set("theme", value.Key);

        WeakReferenceMessenger.Default.Send(new ThemeChangedMessage(value.Key));
    }
}