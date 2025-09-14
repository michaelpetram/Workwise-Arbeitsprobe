using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WpfAddressBook.Models;

namespace WpfAddressBook.Core;

public class ContactDbContext : DbContext
{
    public DbSet<Contact> Contacts => Set<Contact>();

    public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

}

