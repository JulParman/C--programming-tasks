using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_objects
{
    class AccountAction
    {
        private DateTime _date;
        private double _amount;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public AccountAction(DateTime date, double amount)
        {
            _date = date;
            _amount = amount;
        }
    }
}
