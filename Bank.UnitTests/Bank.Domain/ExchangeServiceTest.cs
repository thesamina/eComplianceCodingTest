using Xunit;
using Bank.Domain.Data;
using Bank.Domain.Service;

namespace Bank.UnitTests
{
    public class ExchangeServiceTest
    {
        [Fact]
        public void ConvertCurrenty_Pass()
        {
            //tests currency conversion

            double amt = ExchangeService.ConvertCurrency(100, Constants.Currency.USD, Constants.Currency.CAD);

            Assert.Equal(200, amt);
        }
    }
}