using System;

namespace BankAccount
{
    public class Account
    {
        private Money money;

        public Account()
        {
            money = Money.ValueOf(0);
        }

        public Money GetBalance()
        {
            return money;
        }

        public void Deposit(Money money)
        {
           this.money = this.money.AddMoney(money);
        }

        public void Withdraw(Money money)
        {
            this.money = this.money.Whitedraw(money);
        }
    }
}