using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public class Account
    {
        private static long NextAccountNumber=0;
        public long Accountnumber{ get; set; }
        public string Fname{ get; set; }
        public string Lname{ get; set; }
        public double Balance{ get; set; }

        public Account() { }
        public Account(string firstname, string lastname, float bal)
        {
            NextAccountNumber++;
            Accountnumber = NextAccountNumber;
            Fname = firstname;
            Lname = lastname;
            Balance = bal;
        }
        public void Deposit(float amount) 
        {
            Balance += amount;
        }
        public void Withdraw(float amount) 
        {
            Balance -= amount;
        }
        public static void SetLastAccountNumber(long accountNumber) 
        {
            NextAccountNumber = accountNumber;
        }
        public static long GetLastAccountNumber() { return NextAccountNumber; }
    }
    public class Bank
    {
        private Dictionary<long, Account> accounts = new Dictionary<long, Account>();
        public Bank()
        {
            Account account = new Account();
            Account.SetLastAccountNumber(account.Accountnumber);
        }
        public Account OpenAccount(string fname, string lname, float balance)
        {
            Account account = new Account(fname, lname, balance);
            accounts.Add(account.Accountnumber, account);
            return account;
        }
        public Account BalanceEnquiry(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                return accounts[accountNumber];
            }
            else
                return null;
        }
        public Account Deposit(long accountNumber, float amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                if (amount >= 10000)
                {
                    Console.WriteLine("A user cannot deposit more than $10,000 in a single transaction");
                }
                else
                {
                    accounts[accountNumber].Deposit(amount);
                    Console.WriteLine("Amount is Deposited");
                }
                return accounts[accountNumber];
            }
            else
                return null;
        }
        public Account Withdraw(long accountNumber, float amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                float bal =( (float)accounts[accountNumber].Balance ) * (90f / 100f);

                if (amount > accounts[accountNumber].Balance)
                {
                    Console.WriteLine("Insuffient Funds");
                }
                else if (amount >= bal)
                {
                    Console.WriteLine("A user cannot withdraw more than 90% of their total balance from an account in a single transaction.");
                }
                else
                {
                    accounts[accountNumber].Withdraw(amount);
                    Console.WriteLine("Amount Withdrawn");
                }
                return accounts[accountNumber];
            }
            else
                return null;
        }
        public void CloseAccount(long accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Console.WriteLine("Account Deleted is ");
                accounts.Remove(accountNumber);
            }
            else
                Console.WriteLine("Account Number not found");
        }
        public void ShowAllAccounts()
        {
            foreach (KeyValuePair<long, Account> pair in accounts)
            {
                ShowAccountDetails(pair.Key);
            }
        }
        public void ShowAccountDetails(long accountNumber)
        {
            Console.WriteLine($"Account details are:" + accounts[accountNumber].Accountnumber);
            Console.WriteLine(accounts[accountNumber].Fname);
            Console.WriteLine(accounts[accountNumber].Lname);
            Console.WriteLine(accounts[accountNumber].Balance);
        }
    }

}
