using System;

namespace BankAccount
{
    public class Money
    {
        private readonly double _money;

        private Money(double money)
        {
            if (money < 0)
                throw new ArgumentException("cannot deposit negative money");
            _money = money;
        }

        public static Money ValueOf(double money)
        {
            return new Money(money);
        }

        public Money AddMoney(Money moneyToAdd)
        {
            return new Money(_money+moneyToAdd._money);
        }
        public Money Whitedraw(Money moneyToRemove)
        {
            if(_money - moneyToRemove._money < 0)
                throw  new ArgumentException("account have not enough money");

            return new Money(_money - moneyToRemove._money);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return obj is Money other && _money==other._money;
        }

        public override int GetHashCode()
        {
            return _money.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_money}";
        }

    }
}