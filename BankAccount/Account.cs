using System;
using System.Collections.Generic;

namespace BankAccount
{
    public class Account
    {
        private Money _money;
        private readonly List<Operation> _historics;


        public Account()
        {
            _money = Money.ValueOf(0);
            _historics=new List<Operation>();
        }

        public Money GetBalance()
        {
            return _money;
        }

        public void Deposit(Money money)
        {
           this._money = this._money.AddMoney(money);
           _historics.Add(new Operation(OperationType.Deposit, money, this._money));
        }

        public void Withdraw(Money money)
        {
            this._money = this._money.Whitedraw(money);
            _historics.Add(new Operation(OperationType.Withdrawal, money, this._money));

        }

        public string History()
        {
            return string.Join("\n", _historics);
        }
    }
}