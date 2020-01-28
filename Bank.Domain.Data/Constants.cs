using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Domain.Data
{
    public class Constants
    {
        //due to time contraints I am putting the currency types and exchange amounts in constancts
        //the proper way to do this would be to put the exchange rates in another data model which propely mapped all currency conversion combinations

        public enum Currency
        {
            CAD,
            USD,
            MXN
        }

        public const double EXCHANGE_CAD_TO_USD = 0.5;
        public const double EXCHANGE_CAD_TO_MXN = 10;
    }
}
