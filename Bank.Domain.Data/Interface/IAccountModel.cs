namespace Bank.Domain.Data.Interface
{
    public interface IAccountModel
    {
        IPersonModel AccountOwner{ get; set; }

        int AccountNumber { get; set; }

        double Balance { get; set; }

        Constants.Currency Currency { get; set; }
    }
}