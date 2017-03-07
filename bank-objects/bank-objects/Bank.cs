using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class Bank
    {
        private string _name;
        public static List<BankAccount> _accounts;
        private Random _rnd = new Random();

        public Bank(string name)
        {
            _name = name;
            _accounts = new List<BankAccount>();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string CreateNewAccount()
        {
            string accountNum = "";

            for (int i = 0; i < 15; i++)
            {
                accountNum += _rnd.Next(0, 9).ToString();
            }
            accountNum = "FI" + accountNum;
            _accounts.Add(new BankAccount(accountNum));
            return accountNum;
        }

        public static string SearchBalance(string accountNum)
        {
            double balance = _accounts.Find(x => x.AccountNumber == accountNum).Balance;
            return balance.ToString();
        }

        public string SearchAccountActions(string accountNum)
        {
            string actions = "";
            actions = _accounts.Find(x => x.AccountNumber == accountNum).GiveAllAccountActions(accountNum);
            //for (int i = 0; i < SearchAccountNumberFromBankAccount(accountNum).AccountActions.Count; i++)
            //{
            //    actions += SearchAccountNumberFromBankAccount(accountNum).AccountActions[i].Date.ToString() + " Action: " + SearchAccountNumberFromBankAccount(accountNum).AccountActions[i].Amount.ToString() + "\n";
            //}
            return actions;
        }

        public string SearchAccountActionsBetweenTime(string accountNum, DateTime date1, DateTime date2)
        {
            return _accounts.Find(x => x.AccountNumber == accountNum).GiveActionsBetweenTime(accountNum, date1, date2);
        }

        public BankAccount SearchAccountNumberFromBankAccount(string accountNum)
        {
            return _accounts.First(x => x.AccountNumber == accountNum);
        }

        public void Transfer(string accountNum, double amount)
        {
            //var date = new DateTime(2017, 2, 1);
            //var time = new TimeSpan(9, 30, 0);
            //date = date.Date + time;
            DateTime date = DateTime.Now;
            //AccountAction accountAction = new AccountAction(date, amount);
            //_accounts.Find(x => x.AccountNumber == accountNum).AccountActions.Add(accountAction);
            _accounts.Find(x => x.AccountNumber == accountNum).AccountActions.Add(new AccountAction(date, amount));
            AddTransferToBalance(amount, accountNum);
        }

        public void AddTransferToBalance(double amount, string accountNum)
        {
            _accounts.Find(x => x.AccountNumber == accountNum).Balance += amount;
        }
    }
}
