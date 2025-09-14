using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAddressBook.Models;

namespace WpfAddressBook.ViewModels
{
    public abstract class BaseContactViewModel : BaseViewModel
    {
        private Contact _selectedContact;
        public ObservableCollection<Contact> Contacts { get; set; } = new();

        public Contact SelectedContact
        {
            get => _selectedContact;
            set { _selectedContact = value; OnPropertyChanged(); }
        }

        public BaseContactViewModel()
        {
            AddCommand = new RelayCommand(_ => AddContact());
            DeleteCommand = new RelayCommand(_ => DeleteContact(), _ => SelectedContact != null);
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public abstract void AddContact();
        public abstract void DeleteContact();
    }
}
