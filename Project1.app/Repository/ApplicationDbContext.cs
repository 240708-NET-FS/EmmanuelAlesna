using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project1.app.Repository.Entities;
using Project1.app.Utility;

namespace Project1.app.Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    public ApplicationDbContext()
    { }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Password> Passwords { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
        .HasOne(account => account.Password)
        .WithOne(password => password.Account)
        .HasForeignKey<Password>(password => password.PasswordID)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Account>().HasData(
          new Account { AccountID = -1, Username = "test1" },
          new Account { AccountID = -2, Username = "test2" }
        );

        modelBuilder.Entity<Password>().HasData(
            new Password { PasswordID = -1, Hash = PasswordUtilities.HashPassword("abc123", out byte[] salt), Salt = salt },
            new Password { PasswordID = -2, Hash = PasswordUtilities.HashPassword("123abc", out salt), Salt = salt }

        );
    }
}
