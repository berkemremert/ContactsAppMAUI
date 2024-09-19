using ContactsAppMAUI.Models;
using ContactsAppMAUI.ViewModels;

namespace ContactsAppMAUI.Views.Pages
{
	public partial class ContactListPage : ContentPage
	{
		public ContactListPage()
		{
			InitializeComponent();
			BindingContext = new ContactsViewModel();
		}

		private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item is SimpleContact simpleContact)
			{
				var contactDetailsPageViewModel = new ContactDetailsPageViewModel(
                new ContactsViewModel(),
                Navigation) { SimpleContact = simpleContact};

				var contactDetailPage = new ContactDetailsPage
				{
					BindingContext = contactDetailsPageViewModel
				};
				await Navigation.PushAsync(contactDetailPage);
			}
		}
	}
}