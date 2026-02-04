using System.Net;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Enums;
using Application.Exceptions;
using Application.Models;
using Checkout;
using Checkout.Common;
using Checkout.Payments.Response;
using Infrastructure.Services.Validators;
using Currency = Checkout.Common.Currency;
using Money = Application.Dtos.Money;

namespace Infrastructure.Services.Factories.FactoryItems
{
    public class GetPaymentSessionDetails
    {
        private readonly ICheckoutApi _apiBuild;

        public GetPaymentSessionDetails(ICheckoutApi apiBuild)
        {
            _apiBuild = apiBuild;
        }

        public async Task<PaymentSessionDetailResponse> GetResult(string paymentSessionId)
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

        private PaymentSessionDetailResponse ParseResponse(GetPaymentResponse result)
        {
            return new PaymentSessionDetailResponse()
            {
                Id = result.Id, RequestedOn = result.RequestedOn,
                Reference = result.Reference,
                Amount = ParseMoney(result.Amount, result.Currency),
                Status = ParsePaymentStatus(result.Status),
                IsApproved = result.Approved,
                PaymentType = ParsePaymentType(result.PaymentType),
                Customer = ParseCustomer(result.Customer)
            };
        }

        private Money ParseMoney(long? amount, Currency? currency)
        {
            var anAmount = amount ?? 0;
            var aCurrency = Application.Enums.Currency.GBP;
            if (amount.HasValue) anAmount = amount.Value;

            if (currency.HasValue)
                aCurrency = GlobalMethods.ParseEnum<Application.Enums.Currency>(currency.Value.ToString());

            return new Money(anAmount, aCurrency.ToString());
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

        private Customer ParseCustomer(CustomerResponse customer) =>
            new Customer
            {
                Id = customer.Id,
                FirstName = customer.Name,
                LastName = customer.Name,
                Email = customer.Email
            };
    }
}