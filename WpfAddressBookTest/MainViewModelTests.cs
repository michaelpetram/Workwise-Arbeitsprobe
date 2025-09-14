using WpfAddressBook.ViewModels;
using WpfAddressBook.Models;
using Xunit;

namespace TestProject1;

public class MainViewModelTests
{
    [Fact]
    public void AddCommand_ShouldAddNewContact()
    {
        // Arrange
        var vm = new ContactsViewModel();

        // Act
        vm.AddCommand.Execute(null);

        // Assert
        Assert.Single(vm.Contacts);
        Assert.Equal("Neu", vm.Contacts[0].FirstName);
    }

    [Fact]
    public void DeleteCommand_ShouldRemoveSelectedContact()
    {
        // Arrange
        var vm = new ContactsViewModel();
        vm.Contacts.Add(new Contact { FirstName = "Max", LastName = "Muster" });
        vm.SelectedContact = vm.Contacts[0];

        // Act
        vm.DeleteCommand.Execute(null);

        // Assert
        Assert.Empty(vm.Contacts);
    }

    [Fact]
    public void DeleteCommand_CannotExecute_WithoutSelection()
    {
        // Arrange
        var vm = new ContactsViewModel();
        vm.Contacts.Add(new Contact { FirstName = "Anna" });
        vm.SelectedContact = null;

        // Act
        bool canExecute = vm.DeleteCommand.CanExecute(null);

        // Assert
        Assert.False(canExecute);
    }
}
