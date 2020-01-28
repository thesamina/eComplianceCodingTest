using System;
using Bank.Domain.Data.Interface;

namespace Bank.Domain.Service
{
    public class AccountService
    {
        public enum TransactionResult
        {
            Success,
            InsufficientFunds,
            NoSender,
            NoReciever
        }

        public static TransactionResult MakeWithdrawal(ITransactionModel transaction)
        {
            try
            {
                if (transaction.SenderAcct == null)
                    return TransactionResult.NoSender;

                if (transaction.SenderAcct.Balance < ExchangeService.ConvertCurrency(transaction.TransactionAmt, transaction.Currency, transaction.SenderAcct.Currency))
                    return TransactionResult.InsufficientFunds;

                transaction.SenderAcct.Balance -= ExchangeService.ConvertCurrency(transaction.TransactionAmt, transaction.Currency, transaction.SenderAcct.Currency);
            }
            catch (Exception e)
            {
                throw (e);
            }

            return TransactionResult.Success;
        }

        public static TransactionResult MakeDeposit(ITransactionModel transaction)
        {
            try
            {
                if (transaction.RecieverAcct == null)
                    return TransactionResult.NoReciever;

                transaction.RecieverAcct.Balance += ExchangeService.ConvertCurrency(transaction.TransactionAmt, transaction.Currency, transaction.RecieverAcct.Currency);
            }
            catch (Exception e)
            {
                throw (e);
            }

            return TransactionResult.Success;
        }

        public static TransactionResult MakeTransfer(ITransactionModel transaction)
        {
            try
            {
                TransactionResult result = MakeWithdrawal(transaction);
                if (result != TransactionResult.Success)
                    return result;

                result = MakeDeposit(transaction);
                //desposit amount to reciever account, convert currency to currency of reciever account
                if (result != TransactionResult.Success)
                    return result;
            }
            catch (Exception e)
            {
                throw (e);
            }
           
            return TransactionResult.Success;
        }
    }
}