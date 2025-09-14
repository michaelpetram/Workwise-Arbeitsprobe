using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAddressBook.Core;
using WpfAddressBook.Models;
using WpfAddressBook.Services;

namespace WpfAddressBook.ViewModels
{
    public class ContactsSqliteViewModel : BaseContactViewModel
    {
        
        private readonly ContactDbContext service;
        
        public ContactsSqliteViewModel(): base()
        {
            service = new ContactSqLiteService().CreateContext();
            UpdateView();
        }

        public override void AddContact()
        {
            var newContact = new Contact { FirstName = "Neu", LastName = "Kontakt" };
            service.Add(newContact);
            service.SaveChanges();
            SelectedContact = newContact;
            UpdateView();
        }

        public override void DeleteContact()
        {
            if (SelectedContact != null)
            {
                service.Remove(SelectedContact);
                service.SaveChanges();
                Contacts.Remove(SelectedContact);
                UpdateView();
            }
        }

        private void UpdateView()
        {
            var contacts = service.Contacts;
            Contacts.Clear();
            foreach (var contact in contacts)
            {
                Contacts.Add(contact);
            }
        }
    }
}
