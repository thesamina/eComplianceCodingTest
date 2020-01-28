using Bank.Domain.Data.Interface;

namespace Bank.Domain.Data.Model
{
    public class CustomerModel : IPersonModel
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}