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
        modelBuilder.Entity<Account>().HasOne(a => a.Password).WithOne(p => p.Account).HasForeignKey<Password>(p => p.PasswordID);
        // modelBuilder.Entity<Account>().HasIndex(a => a.AccountID);
        // modelBuilder.Entity<Order>().HasOne(o => o.Account).WithMany(a => a.Orders).HasForeignKey(o => o.AccountID);
    }

}
