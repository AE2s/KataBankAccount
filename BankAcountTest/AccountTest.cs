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
        }

        [TestMethod]
        public void Given_a_whitedraw_of_10_when_account_have_10_should_return_zero()
        {
            Account account=new Account();
            account.Deposit(Money.ValueOf(10));
            account.Withdraw(Money.ValueOf(10));
            Assert.AreEqual(Money.ValueOf(0),account.GetBalance());
        }

        [TestMethod]
        public void Given_a_whitedraw_of_10_when_account_have_50_should_return_40()
        {
            Account account = new Account();
            account.Deposit(Money.ValueOf(50));
            account.Withdraw(Money.ValueOf(10));
            Assert.AreEqual(Money.ValueOf(40), account.GetBalance());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_a_whitedraw_of_10_when_account_have_zero_should_return_exception()
        {
            Account account = new Account();
            account.Withdraw(Money.ValueOf(10));
        }

        [TestMethod]
        public void Given_a_deposit_operation_should_return_historic_of_account()
        {
            string operationExpected=$"Deposit | {DateTime.Now} | 20 | 20";
            Account account=new Account();
            account.Deposit(Money.ValueOf(20));
            Assert.AreEqual(operationExpected, account.History());
        }

        [TestMethod]
        public void Given_some_operations_to_account_should_give_all_historics()
        {
            string operationExpected = $"Deposit | {DateTime.Now} | 20 | 20\nWithdrawal | {DateTime.Now} | 10 | 10";
            Account account = new Account();
            account.Deposit(Money.ValueOf(20));
            account.Withdraw(Money.ValueOf(10));
            Assert.AreEqual(operationExpected, account.History());
        }
    }
}
