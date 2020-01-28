using Bank.Domain.Data.Interface;

namespace Bank.Domain.Data.Model
{
    public class CheckingAcctModel : IAccountModel
    {
        public IPersonModel AccountOwner { get; set; }

        public int AccountNumber { get; set; }

        public double Balance { get; set; }

        public Constants.Currency Currency{ get; set; }
    }
}
