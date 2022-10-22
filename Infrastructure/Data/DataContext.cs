using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions options):base(options)
    {
    }
   
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}