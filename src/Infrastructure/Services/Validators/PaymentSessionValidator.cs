using System.Text.RegularExpressions;
using Application.Enums;
using Checkout.Common;
using Currency = Checkout.Common.Currency;

namespace Infrastructure.Services.Validators
{
    public static class PaymentSessionValidator
    {
        public static bool IsCurrencyValid(Application.Enums.Currency currency) =>
            GlobalMethods.ParseEnum<Currency>(currency.ToString()).ToString() != null;

        public static CountryCode GetCountryCode(AllowedCountry allowedCountry)
        {
            switch (allowedCountry.ToString().ToUpper())
            {
                case nameof(CountryCode):
                default:
                    return CountryCode.GB;
            }
        }

        public static bool IsPaymentSessionIdValid(string paymentSessionId)
        {
            if (string.IsNullOrWhiteSpace(paymentSessionId))
                return false;

            return Regex.IsMatch(
               // paymentSessionId, @"^(pay|sid)_(\w{26})$");
               paymentSessionId, @"^(ps)_(\w{27})$");

            #region Notes about the @"^(ps)_(\w{27})$")

            //^ — start of the string
            //(ps) — the string must begin with either pay or sid
            //_ — a literal underscore
            //(\w{27}) — exactly 26 “word” characters, where \w means:
            //letters A–Z / a–z
            //digits 0–9
            //underscore _
            //$ — end of the string
            //Examples that match:
            //ps_abc123DEF456ghi789JKL0121           

            #endregion
        }
    }
}