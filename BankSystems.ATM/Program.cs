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

List<Account>? accs = Tools.ReadListFromFile();

foreach (Account acc in accs)
{
    Console.WriteLine(acc.Name);
}

string? password = account.GetPassword();
Console.WriteLine($"Acc Password -> {password}");

//......deposit and transfer....//

while (true)
{
    Console.WriteLine("\nChoose operation you want to do");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Transfer");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. Exit\n");

    string? option = Console.ReadLine();
    switch (option)
    {
        case "1":
            Console.WriteLine("Enter amount to deposit:");
            double amount = double.Parse(Console.ReadLine());
            Tools.DepositToAccount(account.BankAccounts[0], amount);
            break;
        case "2":
            Console.WriteLine("Enter amount to transfer:");
            double transferAmount = double.Parse(Console.ReadLine());
            Tools.TransferFromAccount(account.BankAccounts[0], account.BankAccounts[1], transferAmount);
            break;
        case "3":
            Console.WriteLine("Enter amount to withdraw:");
            double withdrawAmount = double.Parse(Console.ReadLine());
            Tools.WithdrawFromAccount(account.BankAccounts[0], withdrawAmount);
            break;
        case "4":
            return;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
}


