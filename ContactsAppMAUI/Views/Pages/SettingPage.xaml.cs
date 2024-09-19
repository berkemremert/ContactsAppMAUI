using Microsoft.Maui.Controls;
using ContactsAppMAUI.Resources.Styles;
using ContactsAppMAUI.ViewModels;

namespace ContactsAppMAUI.Views.Pages
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();

			BindingContext = new SettingsViewModel();
        }
    }
}