using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project1.app.Repository.Entities;

namespace Project1.app.Repository;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    public ApplicationDbContext()
    { }
    public DbSet<Account> Accounts { get; set; }
    // public DbSet<Password> Passwords { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<Account>().HasMany(a => a.Orders).WithOne(o => o.Account).HasForeignKey(a => a.OrderID);
        modelBuilder.Entity<Account>().HasIndex(a => a.AccountID);
    }

}
