using System.Net;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Exceptions;
using Checkout;
using Checkout.Payments.Sessions;
using Infrastructure.Services.Builders;
using Infrastructure.Services.Validators;

namespace Infrastructure.Services.Factories.FactoryItems
{
    public class GeneratePaymentSession
    {
        private readonly ICheckoutApi _apiBuild;

        public GeneratePaymentSession(ICheckoutApi apiBuild)
        {
            _apiBuild = apiBuild;
        }

        public async Task<GeneratedPaymentSessionResponse> GetResult(GeneratePaymentSessionRequest request)
        {
            var paymentResponse = await GetPaymentSession(request);
            return paymentResponse != null
                ? PaymentSessionBuilder.GetGeneratedPaymentSessionResponse(paymentResponse)
                : null;
        }

        private async Task<PaymentSessionsResponse> GetPaymentSession(IGeneratePaymentSessionRequest request)
        {
            if (!PaymentSessionValidator.IsCurrencyValid(request.Money.Currency))
                throw new PaymentProviderException($"Invalid currency '{request.Money.Currency.ToString()}'" +
                                                   " provided", HttpStatusCode.BadRequest);

            var paymentSessionRequest = PaymentSessionBuilder.GetPaymentSessionsRequest(request);
            var paymentResponse = await _apiBuild.PaymentSessionsClient().RequestPaymentSessions
                (paymentSessionRequest);
            return paymentResponse;
        }

        public async Task<GeneratedPaymentSessionRawResponse> GetResult(GenerateRawPaymentSessionRequest request)
        {
             var paymentResponse = await GetPaymentSession(request);
             return paymentResponse != null
                 ? PaymentSessionBuilder.GetGeneratedRawPaymentSessionResponse(paymentResponse)
                 : null;
        }
    }
}