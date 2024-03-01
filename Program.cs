using EFDemo;
using Microsoft.Extensions.DependencyInjection;

// Service collection = pool of central services that anyone in the pool can access
var services = new ServiceCollection();

// AddTransient - any staff member will do, we can grab a different one every time
services.AddTransient<StaffMember>();

// Central database context (database-connected class)
services.AddDbContext<Bank>();

// We've finished planning our services - now put them all together
var serviceProvider = services.BuildServiceProvider();

// Grab a staff member from the pool
var staffMember = serviceProvider.GetRequiredService<StaffMember>();

Console.Write("Enter the name to be associated with the new account: ");
var name = Console.ReadLine() ?? "";
staffMember.OpenAccount(name);

Console.Write("Please enter the ID of the account you wish to view: ");
if (int.TryParse(Console.ReadLine(), out var accountId))
{
    staffMember.ShowAccountDetails(accountId);
}
else
{
    Console.WriteLine("Sorry, that isn't a valid account ID.");
}
