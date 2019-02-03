using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Operation
    {
        private readonly OperationType _operationType;
        private readonly Money _amount;
        private readonly Money _balance;
        private readonly DateTime _date;

        public Operation(OperationType operationType, Money amount, Money balance)
        {
            _operationType = operationType;
            _date=DateTime.Now;
            _amount = amount;
            _balance = balance;
        }

        public override string ToString()
        {
            return $"{_operationType.ToString()} | {_date} | {_amount} | {_balance}";
        }
    }

    public enum OperationType
    {
        Deposit=1,
        Withdrawal=2
    }
}
