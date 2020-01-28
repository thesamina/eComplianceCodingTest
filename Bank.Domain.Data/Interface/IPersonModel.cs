namespace Bank.Domain.Data.Interface
{
    public interface IPersonModel
    {
        int PersonId { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
