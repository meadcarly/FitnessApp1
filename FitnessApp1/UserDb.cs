using FitnessApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FitnessApp1;

public class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> options)
        : base(options)
    {
    }

    //Represents a table in the database
    public DbSet<UserDb> Users { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseMySql(
                configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 33))
            );
        }
    }
}