using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsAppMAUI.Models;

namespace ContactsAppMAUI.ViewModels;

public partial class ContactsViewModel : ObservableObject
{
    [ObservableProperty]
    public ObservableCollection<SimpleContact> simpleContacts = new();

    [ObservableProperty]
    public SimpleContact simpleContact = new();

    public ContactsViewModel()
    {
        LoadContactsFromFile();
    }

    [RelayCommand]
    public void Add()
    {
        SimpleContacts.Add(SimpleContact);
        SimpleContact = new();
        SaveContactsToFile();
    }
    public async Task LoadContactsFromFile()
    {
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "contacts.json");
        if (File.Exists(filePath))
        {
            var json = await File.ReadAllTextAsync(filePath);
            var contacts = JsonSerializer.Deserialize<List<SimpleContact>>(json);
            if (contacts != null)
            {
                foreach (var contact in contacts)
                {
                    SimpleContacts.Add(contact);
                }
            }
        }
    }
    public async Task SaveContactsToFile()
    {
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "contacts.json");
        var json = JsonSerializer.Serialize(SimpleContacts.ToList());
        await File.WriteAllTextAsync(filePath, json);
    }
}