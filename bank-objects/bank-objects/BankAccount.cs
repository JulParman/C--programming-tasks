using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class BankAccount
    {
        private string _accountNumber;
        private List<AccountAction> _accountActions;
        private double _balance;

        public BankAccount(string accountNumber)
        {
            _accountNumber = accountNumber;
            _accountActions = new List<AccountAction>();
            _balance = 0;
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public List<AccountAction> AccountActions
        {
            get { return _accountActions; }
            set { _accountActions = value; }
        }

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public string GiveAllAccountActions(string accountNum)
        {
            string action = "";
            action += accountNum + "\n";
            foreach (AccountAction accountAction in _accountActions)
            {
                action += "Amount: " + accountAction.Amount + " Date: " + accountAction.Date.ToString() + "\n";
            }
            return action;
        }

        public string GiveActionsBetweenTime(string accountNum, DateTime date1, DateTime date2)
        {
            string action = "";
            action += accountNum + "\n";
            foreach (AccountAction accountAction in _accountActions)
            {
                if (accountAction.Date >= date1 && accountAction.Date <= date2)
                {
                    action += "Amount: " + accountAction.Amount + " Date: " + accountAction.Date.ToString() + "\n";
                }

            }
            return action;
        }
    }
}
