using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WpfAddressBook.Core;
using WpfAddressBook.Models;
using WpfAddressBook.Services;
using Xunit;

namespace WpfAddressBookIntegrationTest;

public class ContactIntegrationTests
{
    private ContactDbContext CreateInMemoryContext()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<ContactDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new ContactDbContext(options);
        context.Database.EnsureCreated(); // Tabellen erstellen
        return context;
    }

    [Fact]
    public async Task SaveAndLoadContact_ShouldPersistData()
    {
        // Arrange
        using var context = CreateInMemoryContext();
        var contact = new Contact { FirstName = "Max", LastName = "Muster" };

        // Act
        context.Contacts.Add(contact);
        await context.SaveChangesAsync();

        var loaded = await context.Contacts.FirstAsync();

        // Assert
        Assert.Equal("Max", loaded.FirstName);
        Assert.Equal("Muster", loaded.LastName);
    }

    private ContactDbContext CreateInFileContext()
    {
        var connection = new SqliteConnection("DataSource=Contacts.sqlite");
        connection.Open();

        var options = new DbContextOptionsBuilder<ContactDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new ContactDbContext(options);
        context.Database.EnsureCreated(); // Tabellen erstellen
        return context;
    }

    [Fact]
    public async Task SaveAndLoadContactSqLite_ShouldPersistData()
    {
        // Arrange
        using var context =  new ContactSqLiteService().CreateContext();
        var contact = new Contact { FirstName = "Max", LastName = "Muster" };

        // Act
        context.Contacts.Add(contact);
        await context.SaveChangesAsync();

        var loaded = await context.Contacts.FirstAsync();

        // Assert
        Assert.Equal("Max", loaded.FirstName);
        Assert.Equal("Muster", loaded.LastName);
    }
}
