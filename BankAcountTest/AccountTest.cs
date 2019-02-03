using System;
using System.Security.Principal;
using BankAccount;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAcountTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Given_balance_of_new_account_should_return_zero()
        {
            Account account=new Account();
            var zero = Money.ValueOf(0);
            Assert.AreEqual(zero,account.GetBalance());
        }

        [TestMethod]
        public void Given_fifty_should_return_fifty_in_balance_of_account()
        {
            Account account=new Account();
            var fifty = Money.ValueOf(50);
            account.Deposit(fifty);
            Assert.AreEqual(fifty, account.GetBalance());
        }

        [TestMethod]
        public void Given_two_deposit_should_return_sum_of_both_in_the_balance()
        {
            Account account=new Account();
            Money money = Money.ValueOf(50);
            account.Deposit(money);
            account.Deposit(money);
            Assert.AreEqual(Money.ValueOf(100), account.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_negative_money_should_return_an_argumentException()
        {
            Account account=new Account();
            var money = Money.ValueOf(-10);
            account.Deposit(money);
            Assert.AreEqual(Money.ValueOf(0),account.GetBalance());
        }
    }
}
