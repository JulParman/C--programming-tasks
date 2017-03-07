using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Nordea");
            Customer customer1 = new Customer("Keijo", "Pulkkinen", bank.CreateNewAccount());
            Customer customer2 = new Customer("Masa", "Mattila", bank.CreateNewAccount());
            Customer customer3 = new Customer("Esko", "Mörkö", bank.CreateNewAccount());
            Console.WriteLine(bank.Name);
            Console.WriteLine(customer1.AccountNumber);
            Console.WriteLine(customer2.AccountNumber);
            Console.WriteLine(customer3.AccountNumber);
            bank.Transfer(customer1.AccountNumber, 100);
            bank.Transfer(customer2.AccountNumber, 1000);
            bank.Transfer(customer3.AccountNumber, 120207);
            Console.WriteLine(customer1.ToString());
            Console.WriteLine(customer2.ToString());
            Console.WriteLine(customer3.ToString());
            Console.WriteLine(bank.SearchAccountActions(customer1.AccountNumber));
            Console.WriteLine(bank.SearchAccountActions(customer2.AccountNumber));
            Console.WriteLine(bank.SearchAccountActions(customer3.AccountNumber));
            bank.Transfer(customer1.AccountNumber, -50);
            bank.Transfer(customer2.AccountNumber, -100);
            bank.Transfer(customer3.AccountNumber, -12207);
            Console.WriteLine(customer1.ToString());
            Console.WriteLine(customer2.ToString());
            Console.WriteLine(customer3.ToString());
            Console.WriteLine(bank.SearchAccountActions(customer1.AccountNumber));
            Console.WriteLine(bank.SearchAccountActions(customer2.AccountNumber));
            Console.WriteLine(bank.SearchAccountActions(customer3.AccountNumber));
            DateTime date1 = new DateTime(2017, 03, 05);
            DateTime date2 = new DateTime(2017, 03, 06);
            date1 = date1 + new TimeSpan(9, 30, 0);
            date2 = date2 + new TimeSpan(9, 33, 0);
            Console.WriteLine(bank.SearchAccountActionsBetweenTime(customer1.AccountNumber, date1, date2));
            Console.WriteLine(bank.SearchAccountActionsBetweenTime(customer2.AccountNumber, date1, date2));
            Console.WriteLine(bank.SearchAccountActionsBetweenTime(customer3.AccountNumber, date1, date2));

            Console.ReadKey();
        }
    }
}
