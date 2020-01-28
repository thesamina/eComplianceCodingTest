namespace Bank.Domain.Data.Interface
{
    public interface ITransactionModel
    {
        IAccountModel SenderAcct { get; set; }

        IAccountModel RecieverAcct { get; set; }

        double TransactionAmt { get; set; }

        Constants.Currency Currency { get; set; }
    }
}
