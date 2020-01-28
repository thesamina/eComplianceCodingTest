using Bank.Domain.Data.Interface;

namespace Bank.Domain.Data.Model
{
    public class TransactionModel : ITransactionModel
    {
        public IAccountModel SenderAcct { get; set; }

        public IAccountModel RecieverAcct { get; set; }

        public double TransactionAmt { get; set; }

        public Constants.Currency Currency { get; set; }
    }
}
