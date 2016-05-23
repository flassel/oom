using System;
using System.Net;
using System.Globalization;

namespace Task3
{
    public class Coupon : Product
    {
        public Coupon(decimal value, Currency currency)
        {
            if (value <= 0) throw new ArgumentException("The value must not be 0!", nameof(value));

            Value = value;
            Currency = currency;
            Code = Guid.NewGuid().ToString();
            GotCoupon = false;
        }

        public decimal Value { get; }

        public Currency Currency { get; }

        public string Code { get; }

        public void GoForCoupons()
        {
            if (GotCoupon) throw new InvalidOperationException($"Gift card {Code} has already been redeemed.");
            GotCoupon = true;
        }
        public bool GotCoupon { get; private set; }

        public decimal GetPrice(Currency currency)
        {
            // if the price is requested in it's own currency, then simply return the stored price
            if (currency == Currency) return Value;

            // use web service to query current exchange rate
            // request : http://download.finance.yahoo.com/d/quotes.csv?s=EURUSD=X&f=sl1d1t1c1ohgv&e=.csv
            // response: "EURUSD=X",1.0930,"12/29/2015","6:06pm",-0.0043,1.0971,1.0995,1.0899,0
            var key = string.Format("{0}{1}", Currency, currency); // e.g. EURUSD means "How much is 1 EUR in USD?".

            // create the request URL, ...
            var url = string.Format(@"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv", key);
            // download the response as string
            var data = new WebClient().DownloadString(url);
            // split the string at ','
            var parts = data.Split(',');
            // convert the exchange rate part to a decimal 
            var rate = decimal.Parse(parts[1], CultureInfo.InvariantCulture);

            // and finally perform the currency conversion
            return Value * rate;
        }

        public string Description => "Coupon " + Code;
    }
}
