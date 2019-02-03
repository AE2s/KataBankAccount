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
            this.money += money;
        }
    }
}