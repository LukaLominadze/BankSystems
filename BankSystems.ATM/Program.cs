using BankSystems.Core;

Tools.Initialize(Roles.Admin);

Account account = new("Saba", "Saba123");

account.AddBankAccount(new BankAccount() { Id = "1", Balance = 10 });
account.AddBankAccount(new BankAccount() { Id = "2", Balance = 11 });
account.AddBankAccount(new BankAccount() { Id = "3", Balance = 12 });
account.AddBankAccount(new BankAccount() { Id = "4", Balance = 13 });

account.RemoveBankAccount("3");
account.RemoveBankAccount("5");

Tools.WriteListToFile(new List<Account>() { account });

List<Account> accs = Tools.ReadListFromFile();

foreach (Account acc in accs)
{
    Console.WriteLine(acc.Name);
}

string password = account.GetPassword();
Console.WriteLine($"Acc Password -> {password}");