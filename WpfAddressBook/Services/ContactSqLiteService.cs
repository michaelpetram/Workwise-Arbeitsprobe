using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAddressBook.Core;

namespace WpfAddressBook.Services
{
    public class ContactSqLiteService
    {
        public ContactDbContext CreateContext()
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

    }
}
