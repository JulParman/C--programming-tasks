using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class Customer
    {
        private string _firstName;
        private string _secondName;
        private string _accountNumber;

        public Customer(string firstName, string secondName, string accountNumber)
        {
            _firstName = firstName;
            _secondName = secondName;
            _accountNumber = accountNumber;
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; }
        }

        public string PrintCustomer()
        {
            return AccountNumber + " " + FirstName + " " + SecondName + " Balance: " + Bank.SearchBalance(AccountNumber);
        }

        public override string ToString()
        {
            return PrintCustomer();
        }
    }
}
