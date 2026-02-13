using System.Net;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Enums;
using Application.Exceptions;
using Checkout;
using Checkout.Payments.Response;
using Checkout.Payments.Response.Source;
using Infrastructure.Services.Validators;
using Currency = Checkout.Common.Currency;

namespace Infrastructure.Services.Factories.FactoryItems
{
    public class GetPaymentSessionDetails
    {
        private readonly ICheckoutApi _apiBuild;

        public GetPaymentSessionDetails(ICheckoutApi apiBuild)
        {
            _apiBuild = apiBuild;
        }

        public async Task<PaymentSessionDetailResponseDto> GetResult(string paymentSessionId)
        {
            if (!PaymentSessionValidator.IsPaymentSessionIdValid(paymentSessionId))
                throw new PaymentProviderException
                    ($"Please provide a valid {nameof(paymentSessionId)}.", HttpStatusCode.BadRequest);

            var result = await _apiBuild.PaymentsClient().GetPaymentDetails(paymentSessionId);

            if (result is null)
                throw new PaymentProviderException
                    ($"Null result gotten from GetPaymentDetails", HttpStatusCode.InternalServerError);

            return ParseResponse(result);
        }

        private PaymentSessionDetailResponseDto ParseResponse(GetPaymentResponse result)
        {
            var source = result.Source as CardResponseSource;
            if (source is null)
                throw new PaymentProviderException("Invalid card response", HttpStatusCode.InternalServerError);

            return new PaymentSessionDetailResponseDto(result.Id, result.RequestedOn,
                ParsePaymentSessionDetailSource(source),
                ParsePaymentType(result.PaymentType), ParseMoney(result.Amount, result.Currency),
                result.Reference,
                result.Description, result.Approved, ParsePaymentStatus(result.Status),
                ParseCustomer(result));
        }

        private MoneyDto ParseMoney(long? amount, Currency? currency)
        {
            var anAmount = amount ?? 0;
            var aCurrency = Application.Enums.Currency.GBP;
            if (amount.HasValue) anAmount = amount.Value;

            if (currency.HasValue)
                aCurrency = GlobalMethods.ParseEnum<Application.Enums.Currency>(currency.Value.ToString());

            return new MoneyDto(anAmount, aCurrency.ToString());
        }

        private string ParsePaymentStatus(Checkout.Payments.PaymentStatus? status)
            => status is null
                ? null
                : GlobalMethods.ParseEnum<PaymentStatus>
                    (status.Value.ToString()).ToString();

        private string ParsePaymentType(Checkout.Payments.PaymentType? paymentType)
            => paymentType is null
                ? null
                : GlobalMethods.ParseEnum<PaymentType>(paymentType.Value.ToString()).ToString();

        private PaymentSessionCustomerDto ParseCustomer(GetPaymentResponse result) =>
            new PaymentSessionCustomerDto(result.Customer.Id, result.Customer.Email, result.Customer.Name);

        private PaymentSessionDetailSourceDto ParsePaymentSessionDetailSource(CardResponseSource source) =>
            new PaymentSessionDetailSourceDto(source.Id, source.ExpiryMonth, source.ExpiryYear, source.Name,
                source.Last4);
    }
}