using System;
using Microsoft.EntityFrameworkCore;
using PhonebookProject.Domain;

namespace PhonebookProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}

