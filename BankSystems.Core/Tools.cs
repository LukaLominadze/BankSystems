
using Newtonsoft.Json;

namespace BankSystems.Core
{
   
    public enum Roles
    {
        User, Admin
    }

    public static class Tools
    {
        private static string AccountsFilePath = "Accounts.json";
        public static Roles Role { get; private set; }

        public static void Initialize(Roles role)
        {
            Role = role;
        }

        public static void WriteListToFile(List<Account> accounts)
        {
            string jsonData = JsonConvert.SerializeObject(accounts);
            File.WriteAllText(AccountsFilePath, jsonData);

        }

        public static List<Account>? ReadListFromFile()
        {
            string recievedJsonDataString = string.Empty;

            try
            {
                recievedJsonDataString = File.ReadAllText(AccountsFilePath);
            }
            catch
            {
                Console.WriteLine("Such file not fount yet");
                return null;
            }

            List<Account>? accounts = JsonConvert.DeserializeObject<List<Account>>(recievedJsonDataString);

            return accounts;
        }


        //..added deposit and transfer methods..//

        public static void DepositToAccount(BankAccount account, double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            account.Balance += amount;
            Console.WriteLine($"Deposited {amount} to account {account.Id}. New balance: {account.Balance}");
        }

        public static void TransferFromAccount(BankAccount fromAccount, BankAccount toAccount, double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be positive.");
                return;
            }
            if (fromAccount.Balance < amount)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Insufficient funds for transfer. Your balance is {fromAccount.Balance}");
                Console.ResetColor();
                return;
            }
            fromAccount.Balance -= amount;
            toAccount.Balance += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Transferred {amount} from account {fromAccount.Id} to account {toAccount.Id}. New balance: {fromAccount.Balance}");
            Console.ResetColor();
        }


        //....added withdraw method...//


        public static void WithdrawFromAccount(BankAccount account, double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdraw amount must be positive.");
                return;
            }
            if (account.Balance < amount)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Insufficient funds for withdrawal. Your balance is {account.Balance}");
                Console.ResetColor();
                return;
            }
            account.Balance -= amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Withdrew {amount} from account {account.Id}. New balance: {account.Balance}");
            Console.ResetColor();
        }
    }
}
