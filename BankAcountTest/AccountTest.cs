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
            Assert.AreEqual(0,account.GetBalance());
        }

        [TestMethod]
        public void Given_fifty_should_return_fifty_in_balance_of_account()
        {
            Account account=new Account();
            account.Deposit(50);
            Assert.AreEqual(50, account.GetBalance());
        }

        [TestMethod]
        public void Given_two_deposit_should_return_sum_of_both_in_the_balance()
        {
            Account account=new Account();
            account.Deposit(50);
            account.Deposit(50);
            Assert.AreEqual(100, account.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_negative_money_should_return_an_argumentException()
        {
            Account account=new Account();
            account.Deposit(-10);
            Assert.AreEqual(0,account.GetBalance());
        }
    }
}
