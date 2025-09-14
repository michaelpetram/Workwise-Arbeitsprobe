using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfAddressBook.Models;
using WpfAddressBook.Services;

namespace WpfAddressBook.ViewModels
{
    public class ContactsViewModel : BaseContactViewModel
    {
        public override void AddContact()
        {
            var newContact = new Contact { FirstName = "Neu", LastName = "Kontakt" };
            Contacts.Add(newContact);
            SelectedContact = newContact;
        }
        public override void DeleteContact()
        {
            if (SelectedContact != null)
                Contacts.Remove(SelectedContact);
        }
    }
}
