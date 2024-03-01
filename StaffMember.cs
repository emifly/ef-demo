using Microsoft.EntityFrameworkCore;

namespace EFDemo;

public class StaffMember
{
    private readonly Bank _bank;

    public StaffMember(Bank bank)
    {
        _bank = bank;
    }

    public void ShowAccountDetails(int id)
    {
        var matchingAccount = _bank
            .Accounts
            .Include(account => account.InTransactions)                 // Which transactions are coming in?
            .ThenInclude(transaction => transaction.SenderAccount)      // Where are they coming from?
            .Include(account => account.OutTransactions)                // Separately, which transactions are going out?
            .ThenInclude(transaction => transaction.RecipientAccount)   // Where are they going to?
            .SingleOrDefault(account => account.Id == id);
        if (matchingAccount == null)
        {
            Console.WriteLine($"Sorry, I don't recognise the account ID '{id}'.");
        }
        else
        {
            Console.WriteLine("Here are your account details:");
            Console.WriteLine(matchingAccount);
            if (matchingAccount.Transactions.Any())
            {
                Console.WriteLine("Here are your last few transactions:");
                foreach (var transaction in matchingAccount.Transactions.TakeLast(10))
                {
                    Console.WriteLine(transaction);
                }
            }
            else
            {
                Console.WriteLine("No transactions to show yet.");
            }
        }
    }

    public void OpenAccount(string accountName)
    {
        _bank.Accounts.Add(new Account
        {
            Name = accountName,
        });
        // Remember to save your changes - otherwise your new account will be lost
        _bank.SaveChanges();
    }
}
