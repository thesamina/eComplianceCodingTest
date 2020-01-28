using Xunit;
using Bank.Domain.Data;
using Bank.Domain.Data.Interface;
using Bank.Domain.Data.Model;
using Bank.Domain.Service;

namespace Bank.UnitTests
{
    public class TransactionServiceTest
    {
        [Fact]
        public void Withdrawal_Pass()
        {
            //tests withdrawal from one account

            IPersonModel customer = new CustomerModel
            {
                PersonId = 1,
                FirstName = "Bob",
                LastName = "Brat"
            };

            IAccountModel acct = new CheckingAcctModel
            {
                AccountOwner = customer,
                AccountNumber = 1234,
                Balance = 100,
                Currency = Constants.Currency.CAD
            };

            ITransactionModel transModel = new TransactionModel
            {
                SenderAcct = acct,
                TransactionAmt = 50,
                Currency = Constants.Currency.CAD
            };

            //withdraw 50 CAD
            AccountService.MakeWithdrawal(transModel);

            Assert.Equal(50, acct.Balance);
        }

        [Fact]
        public void Withdrawal_DifferentCurrency_Pass()
        {
            //tests withdrawal from one account with a sifferent currency

            IPersonModel customer = new CustomerModel
            {
                PersonId = 1,
                FirstName = "Bob",
                LastName = "Brat"
            };

            IAccountModel acct = new CheckingAcctModel
            {
                AccountOwner = customer,
                AccountNumber = 1234,
                Balance = 100,
                Currency = Constants.Currency.CAD
            };

            ITransactionModel transModel = new TransactionModel
            {
                SenderAcct = acct,
                TransactionAmt = 50,
                Currency = Constants.Currency.USD
            };

            //withdraw 50 USD
            AccountService.MakeWithdrawal(transModel);

            Assert.Equal(0, acct.Balance);
        }

        [Fact]
        public void Deposit_Pass()
        {
            //tests deposit to one account

            IPersonModel customer = new CustomerModel
            {
                PersonId = 777,
                FirstName = "Stewie",
                LastName = "Griffin"
            };

            IAccountModel acct = new CheckingAcctModel
            {
                AccountOwner = customer,
                AccountNumber = 1234,
                Balance = 100,
                Currency = Constants.Currency.CAD
            };

            ITransactionModel transModel = new TransactionModel
            {
                RecieverAcct = acct,
                TransactionAmt = 300,
                Currency = Constants.Currency.USD
            };

            //deposit 300 CAD
            AccountService.MakeDeposit(transModel);

            Assert.Equal(700, acct.Balance);
        }

        [Fact]
        public void Deposit_DifferentCurrency_Pass()
        {
            //tests deposit to one account

            IPersonModel customer = new CustomerModel
            {
                PersonId = 777,
                FirstName = "Stewie",
                LastName = "Griffin"
            };

            IAccountModel acct = new CheckingAcctModel
            {
                AccountOwner = customer,
                AccountNumber = 1234,
                Balance = 100,
                Currency = Constants.Currency.CAD
            };

            ITransactionModel transModel = new TransactionModel
            {
                RecieverAcct = acct,
                TransactionAmt = 50,
                Currency = Constants.Currency.USD
            };

            //deposit 50 USD
            AccountService.MakeDeposit(transModel);

            Assert.Equal(200, acct.Balance);
        }

        [Fact]
        public void SingleAccountTransactions_Pass()
        {
            //tests multiple transactions on the same account with different currencies

            IPersonModel customer = new CustomerModel
            {
                PersonId = 504,
                FirstName = "Glenn",
                LastName = "Quagmire"
            };

            IAccountModel acct = new CheckingAcctModel
            {
                AccountOwner = customer,
                AccountNumber = 2001,
                Balance = 35000,
                Currency = Constants.Currency.CAD
            };

            ITransactionModel transModel = new TransactionModel
            {
                SenderAcct = acct,
                TransactionAmt = 5000,
                Currency = Constants.Currency.MXN
            };

            //withdraw 500 MXN
            AccountService.MakeWithdrawal(transModel);
            
            transModel.TransactionAmt = 12500;
            transModel.Currency = Constants.Currency.USD;

            //withdraw 500 USD
            AccountService.MakeWithdrawal(transModel);
            
            transModel.SenderAcct = null;
            transModel.RecieverAcct = acct;
            transModel.TransactionAmt = 300;
            transModel.Currency = Constants.Currency.CAD;

            //deposit 300 CAD
            AccountService.MakeDeposit(transModel);

            Assert.Equal(9800, acct.Balance);
        }

        [Fact]
        public void MultipleTransactions1_Pass()
        {
            //tests multiple transactions between 2 account in differency currencies

            IPersonModel customer = new CustomerModel
            {
                PersonId = 002,
                FirstName = "Joe",
                LastName = "Swanson"
            };

            IAccountModel acct1 = new CheckingAcctModel
            {
                AccountOwner = customer,
                AccountNumber = 1010,
                Balance = 7425,
                Currency = Constants.Currency.CAD
            };

            IAccountModel acct2 = new CheckingAcctModel
            {
                AccountOwner = customer,
                AccountNumber = 5500,
                Balance = 15000,
                Currency = Constants.Currency.CAD
            };

            ITransactionModel transModel = new TransactionModel
            {
                SenderAcct = acct2,
                TransactionAmt = 5000,
                Currency = Constants.Currency.CAD
            };

            //widthdraw 5000 CAD
            AccountService.MakeWithdrawal(transModel);

            transModel.SenderAcct = acct1;
            transModel.RecieverAcct = acct2;
            transModel.TransactionAmt = 7300;
            transModel.Currency = Constants.Currency.CAD;

            //transfer 7300
            AccountService.MakeTransfer(transModel);
            
            transModel.SenderAcct = null;
            transModel.RecieverAcct = acct1;
            transModel.TransactionAmt = 13726;
            transModel.Currency = Constants.Currency.MXN;

            //Deposity 13726
            AccountService.MakeDeposit(transModel);

            Assert.Equal(1497.60, acct1.Balance);
            Assert.Equal(17300.00, acct2.Balance);
        }

        [Fact]
        public void MultipleTransactions2_Pass()
        {
            //tests multiple transactions between 2 account in differency currencies

            IPersonModel customer1 = new CustomerModel
            {
                PersonId = 123,
                FirstName = "Peter",
                LastName = "Griffin"
            };

            IPersonModel customer2 = new CustomerModel
            {
                PersonId = 456,
                FirstName = "Lois",
                LastName = "Griffin"
            };

            IAccountModel acct1 = new CheckingAcctModel
            {
                AccountOwner = customer1,
                AccountNumber = 0123,
                Balance = 150,
                Currency = Constants.Currency.CAD
            };

            IAccountModel acct2 = new CheckingAcctModel
            {
                AccountOwner = customer2,
                AccountNumber = 0456,
                Balance = 65000,
                Currency = Constants.Currency.CAD
            };

            ITransactionModel transModel = new TransactionModel
            {
                SenderAcct = acct1,
                TransactionAmt = 70,
                Currency = Constants.Currency.USD
            };

            //withdrawal 70 
            AccountService.MakeWithdrawal(transModel);

            transModel.SenderAcct = null;
            transModel.RecieverAcct = acct2;
            transModel.TransactionAmt = 23789;
            transModel.Currency = Constants.Currency.USD;

            //deposit 23789
            AccountService.MakeDeposit(transModel);
                
            transModel.SenderAcct = acct2;
            transModel.RecieverAcct = acct1;
            transModel.TransactionAmt = 23.75;
            transModel.Currency = Constants.Currency.CAD;

            //transfer 13726
            AccountService.MakeTransfer(transModel);

            Assert.Equal(33.75, acct1.Balance);
            Assert.Equal(112554.25, acct2.Balance);
        }

        [Fact]
        public void Withdrawal_NoSender_Fail()
        {
            //tests withdrawal with missing sender

            ITransactionModel transModel = new TransactionModel
            {
                SenderAcct = null,
                TransactionAmt = 50,
                Currency = Constants.Currency.CAD
            };

            AccountService.TransactionResult result = AccountService.MakeWithdrawal(transModel);

            Assert.Equal(AccountService.TransactionResult.NoSender, result);
        }

        [Fact]
        public void Withdrawal_InsufficientFunds_Fail()
        {
            //tests withdrawal with insufficient funds in account

            IPersonModel customer1 = new CustomerModel
            {
                PersonId = 123,
                FirstName = "Peter",
                LastName = "Griffin"
            };

            IAccountModel acct1 = new CheckingAcctModel
            {
                AccountOwner = customer1,
                AccountNumber = 0456,
                Balance = 20,
                Currency = Constants.Currency.CAD
            };

            ITransactionModel transModel = new TransactionModel
            {
                SenderAcct = acct1,
                TransactionAmt = 50,
                Currency = Constants.Currency.CAD
            };

            AccountService.TransactionResult result = AccountService.MakeWithdrawal(transModel);

            Assert.Equal(AccountService.TransactionResult.InsufficientFunds, result);
        }

        [Fact]
        public void Deposit_NoReciever_Fail()
        {
            //tests deposit with no reciever

            ITransactionModel transModel = new TransactionModel
            {
                RecieverAcct = null,
                TransactionAmt = 50,
                Currency = Constants.Currency.CAD
            };

            AccountService.TransactionResult result = AccountService.MakeDeposit(transModel);

            Assert.Equal(AccountService.TransactionResult.NoReciever, result);
        }
    }
}