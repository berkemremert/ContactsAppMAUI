ContactsApp MAUI


Overview

ContactsApp MAUI is a mobile application developed using .NET MAUI, allowing users to manage their personal contacts. The app enables users to add, edit, and delete contacts, with data stored locally in a JSON file. Additionally, it features a theme customization option and follows the MVVM (Model-View-ViewModel) architecture, ensuring a clear separation between UI and business logic.


Features

Add New Contacts: Input first name, last name, phone number, and address. Optionally, mark contacts as favorites.
Edit Existing Contacts: Modify contact details and save changes.
Delete Contacts: Remove unwanted contacts from the list.
Local Storage: Contact information is stored in a JSON file for persistence.
Theming: Users can switch between different themes (system default, dark, light, or custom).
Contact List: View all saved contacts, displaying names and phone numbers.


Technologies Used

.NET MAUI: Cross-platform framework for building mobile and desktop applications.
MVVM Architecture: Uses CommunityToolkit.Mvvm to follow the Model-View-ViewModel pattern.
Local Storage: Contacts are stored in a JSON file within the app’s local directory.
XAML: Extensively used for defining the UI layout of the app.


Project Structure


ViewModels

ContactsViewModel.cs
Manages the list of contacts, allowing users to add new contacts, edit existing ones, and save or load them from local storage. This class also handles the deletion of contacts.

ContactDetailsPageViewModel.cs
Handles contact detail pages, allowing users to edit, save, and delete contacts. It integrates navigation logic, which redirects users to the contact list upon action completion.

SettingsViewModel.cs
Manages theme settings and allows users to switch between predefined themes and custom themes.

Models
SimpleContact.cs
Represents a contact with fields such as FirstName, LastName, PhoneNumber, Address, and IsFav to mark the contact as a favorite.

Theme.cs
Represents different theme options, each with a name and key.


Views

ContactDetailsPage.xaml
Displays detailed contact information and allows users to modify contact details. It also includes buttons for saving changes and deleting contacts.

ContactListPage.xaml
Lists all contacts saved in the app. Users can add new contacts and view or modify existing ones. Each contact displays the first name and phone number.

SettingPage.xaml
Provides a UI for selecting the app’s theme. Users can choose from system default, dark, light, or custom themes.


Models

SimpleContact.cs: A basic model representing a contact entity with first name, last name, phone number, address, and a favorite flag.
Installation


Clone the repository.

Open the solution in Visual Studio 2022 or later with .NET MAUI workload installed.

Build and run the app on your target device or emulator (Android, iOS, or Windows).


Usage

Add a Contact: Navigate to the contact list, input the contact’s details, and tap the “Add Contact” button to save.
Edit/Delete a Contact: Tap an existing contact in the list to navigate to its detail page. Modify the information and save, or tap "Delete" to remove the contact.
Theme Settings: Access the settings page to change the theme of the app's user interface.


Dependencies

CommunityToolkit.Mvvm: Simplifies MVVM with observable properties and commands.
System.Text.Json: Serializes and deserializes contact data into JSON format.
Microsoft.Maui.Controls: Provides the foundation for building the app’s UI with XAML.
