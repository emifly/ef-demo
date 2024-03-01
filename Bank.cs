using Microsoft.EntityFrameworkCore;

namespace EFDemo;

public class Bank : DbContext
{
    // These are the tables that should be in the database
    public DbSet<Account> Accounts { get; set; } = null!;
    public DbSet<Account> Transactions { get; } = null!;

    // Sorting out actual database connection stuff
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=bank; Username=bank; Password=bank;");
    }

    // Sorting out model relationships and sample data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Make some accounts
        var nandinisAccount = new Account
        {
            Id = -1,
            Name = "Nandini",
        };
        var olhasAccount = new Account
        {
            Id = -2,
            Name = "Olha",
        };
        // Say that the accounts belong to the account table
        modelBuilder.Entity<Account>().HasData(nandinisAccount);
        modelBuilder.Entity<Account>().HasData(olhasAccount);

        // Make some transactions
        var transaction = new Transaction
        {
            Id = -1,
            SenderAccountId = nandinisAccount.Id,
            RecipientAccountId = olhasAccount.Id,
            Amount = 10m,
            Reference = "Mushroom burger",
        };
        // Say that the transactions belong to the transaction table 
        modelBuilder.Entity<Transaction>().HasData(transaction);
    }
}
