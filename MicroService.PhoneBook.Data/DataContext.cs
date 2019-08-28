using MicroService.PhoneBook.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace MicroService.PhoneBook.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        { }

        public DbSet<EntryEntity> Entry { get; set; }
    }
}
