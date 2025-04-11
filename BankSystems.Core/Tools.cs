using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static List<Account> ReadListFromFile()
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

            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(recievedJsonDataString);

            return accounts;
        }
    }
}
