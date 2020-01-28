using Bank.Domain.Data;

namespace Bank.Domain.Service
{
    public class ExchangeService
    {
        public static double ConvertCurrency(double amt, Constants.Currency amtCurrency, Constants.Currency convCurrency)
        {
            //only handles conversion to canadian but can be modified to handle all conversions of currencies through some 
            //data source that maps currencies so you wouldn't need to handles each case with seperate if statements
            switch (amtCurrency)
            {
                case Constants.Currency.MXN: if (convCurrency == Constants.Currency.CAD) return (amt / Constants.EXCHANGE_CAD_TO_MXN); break;
                case Constants.Currency.USD: if (convCurrency == Constants.Currency.CAD) return (amt / Constants.EXCHANGE_CAD_TO_USD); break;
            }

            return amt; //value not converted
        }
    }
}
