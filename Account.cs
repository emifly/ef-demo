using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo;

public class Account
{
    public int Id { get; set; }

    public required string Name { get; set; }

    [InverseProperty(nameof(Transaction.RecipientAccount))]
    public List<Transaction> InTransactions { get; set; } = [];

    [InverseProperty(nameof(Transaction.SenderAccount))]
    public List<Transaction> OutTransactions { get; set; } = [];

    [NotMapped]
    public List<Transaction> Transactions => InTransactions.Concat(OutTransactions).OrderBy(transaction => transaction.Timestamp).ToList();

    public decimal Balance => InTransactions.Sum(transaction => transaction.Amount) - OutTransactions.Sum(transaction => transaction.Amount);

    public override string ToString()
    {
        return $"Account ID: {Id}, Name: {Name}, Balance: {Balance}";
    }
}
