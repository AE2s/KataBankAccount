using System;

namespace BankAccount
{
    public class Account
    {
        private double money;

        public Account()
        {
            money = 0;
        }

        public double GetBalance()
        {
            return money;
        }

        public void Deposit(double money)
        {
            if(money <= 0)
                throw new ArgumentException("cannot deposit negative money");

            this.money += money;
        }
    }
}