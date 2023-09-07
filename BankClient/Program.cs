using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem;

namespace BankClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bOb = new Bank();
            Account acc;
            int choice;
            string fname, lname;
            long accountNumber;
            float balance;
            float amount;
            Console.WriteLine("Banking System");
            do
            {
                Console.WriteLine("\n\tSelect one option below:");
                Console.WriteLine("\n\t1 Open an Account");
                Console.WriteLine("\n\t2 Balance Enquiry");
                Console.WriteLine("\n\t3 Deposit");
                Console.WriteLine("\n\t4 Withdrawal");
                Console.WriteLine("\n\t5 Close an Account");
                Console.WriteLine("\n\t6 Show All Accounts");
                Console.WriteLine("\n\t7 Quit");
                Console.WriteLine("\nEnter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter First Name: ");
                        fname = Console.ReadLine();
                        Console.WriteLine("Enter Last Name: ");
                        lname = Console.ReadLine(); ;
                        Console.WriteLine("Enter initial Balance: ");
                        balance = ((float)Convert.ToDouble(Console.ReadLine()));
                        acc = bOb.OpenAccount(fname, lname, balance);
                        Console.WriteLine("Congratulations Account is Created");
                        bOb.ShowAccountDetails(acc.Accountnumber);
                        break;

                    case 2:
                        Console.WriteLine("Enter Account Number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        acc = bOb.BalanceEnquiry(accountNumber);
                        if (acc != null)
                        {
                            Console.WriteLine("Your Account Details are here:");
                            bOb.ShowAccountDetails(acc.Accountnumber);
                        }
                        else
                        {
                            Console.WriteLine("Account Number not found");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter Account Number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter The Amount to Deposit:");
                        amount = Convert.ToInt32(Console.ReadLine());
                        acc = bOb.Deposit(accountNumber, amount);
                        if (acc != null)
                        {
                            bOb.ShowAccountDetails(acc.Accountnumber);
                        }
                        else
                        {
                            Console.WriteLine("Account Number not found");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Account Number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter The amount to Withdraw:");
                        amount = (float)Convert.ToDouble(Console.ReadLine());
                        acc = bOb.Withdraw(accountNumber, amount);
                        if (acc != null)
                        {
                            bOb.ShowAccountDetails(acc.Accountnumber);
                        }
                        else
                        {
                            Console.WriteLine("Account Number not found");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter Account Number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        bOb.CloseAccount(accountNumber);
                        Console.WriteLine("Account is Closed");
                        break;

                    case 6:
                        bOb.ShowAllAccounts();
                        break;

                    case 7:
                        break;

                    default:
                        Console.WriteLine("nEnter corret choice");
                        break;
                }
                accountNumber = -1;
                balance = 0;
                amount = 0;
            }while (choice != 7);
        }
    }
}
