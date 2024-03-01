using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo;

public class Transaction
{
    public int Id { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public int SenderAccountId { get; set; }

    [ForeignKey("SenderAccountId")]
    public Account SenderAccount { get; set; } = null!;

    public int RecipientAccountId { get; set; }

    [ForeignKey("RecipientAccountId")]
    public Account RecipientAccount { get; set; } = null!;

    public required decimal Amount { get; set; }

    public required string Reference { get; set; }

    public override string ToString()
    {
        return $"Transaction ID: {Id}, Timestamp: {Timestamp}, Sender: {SenderAccount.Name}, Recipient: {RecipientAccount.Name}, Amount: {Amount}, Reference: {Reference}";
    }
}
