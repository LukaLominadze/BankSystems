using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystems.Core
{
    public class Account
    {
        public string Name { get; private set; }
        [JsonProperty]
        private string password { get; set; }
        public List<BankAccount> BankAccounts { get; private set; }

        // constructor
        public Account(string name, string password)
        {
            BankAccounts = new ();
            Name = name;
            this.password = password;
        }

        public void AddBankAccount(BankAccount newBankAccount)
        {
            BankAccounts.Add(newBankAccount);
        }

        public void RemoveBankAccount(string id)
        {
            BankAccount acc = BankAccounts.FirstOrDefault(a => a.Id == id);

            if (acc == null)
            {
                Console.WriteLine("Account with id does not exist!");
                return;
            }

            BankAccounts.Remove(acc);

            foreach(var a in BankAccounts)
            {
                Console.WriteLine(a.Id);
            }
        }

        public string GetPassword()
        {
            if (Tools.Role == Roles.User)
            {
                return password;
            }
            return null;
        }
    }
}
