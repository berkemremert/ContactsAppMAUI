using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsAppMAUI.Models;
using ContactsAppMAUI.Views;
using Microsoft.Maui.Controls;
using ContactsAppMAUI.Views.Pages;

namespace ContactsAppMAUI.ViewModels
{
    public partial class ContactDetailsPageViewModel : ObservableObject
    {
        private readonly ContactsViewModel _contactsViewModel;
        private readonly INavigation _navigation;

        public ContactDetailsPageViewModel(ContactsViewModel contactsViewModel, INavigation navigation)
        {
            _contactsViewModel = contactsViewModel;
            _navigation = navigation;
        }

        [ObservableProperty]
        private SimpleContact simpleContact;

        [RelayCommand]
        private async Task Save()
        {
            if (SimpleContact == null)
                return;

            var existingContact = _contactsViewModel.SimpleContacts
                .FirstOrDefault(c => c.PhoneNumber == SimpleContact.PhoneNumber);

            if (existingContact != null)
            {
                existingContact.FirstName = SimpleContact.FirstName;
                existingContact.LastName = SimpleContact.LastName;
                existingContact.Address = SimpleContact.Address;
                existingContact.PhoneNumber = SimpleContact.PhoneNumber;
                existingContact.IsFav = SimpleContact.IsFav;
            }
            else
            {
                _contactsViewModel.SimpleContacts.Add(SimpleContact);
            }

            await _contactsViewModel.SaveContactsToFile();
            await NavigateToContactListPage();
        }

        [RelayCommand]
        private async Task Delete()
        {
            if (SimpleContact == null)
                return;

            var contactToDelete = _contactsViewModel.SimpleContacts
                .FirstOrDefault(c => c.PhoneNumber == SimpleContact.PhoneNumber);

            if (contactToDelete != null)
            {
                _contactsViewModel.SimpleContacts.Remove(contactToDelete);
                await _contactsViewModel.SaveContactsToFile();
            }

            await NavigateToContactListPage();
        }

        private async Task NavigateToContactListPage()
        {
            // Create a new NavigationPage with ContactListPage as its root
            var newNavigationPage = new NavigationPage(new ContactListPage());

            // Replace the entire navigation stack with the new NavigationPage
            Application.Current.MainPage = newNavigationPage;
        }
    }
}
