using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace razorpagesExample.Models;

public class DataContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

}