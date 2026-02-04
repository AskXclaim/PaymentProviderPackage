using System.Net;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Exceptions;
using Checkout;
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
            if (!PaymentSessionValidator.IsCurrencyValid(request.Money.Currency))
                throw new PaymentProviderException($"Invalid currency '{request.Money.Currency.ToString()}'" +
                                                   $" provided", HttpStatusCode.BadRequest);

            var paymentSessionBuilder = new PaymentSessionBuilder();
            var paymentSessionRequest = paymentSessionBuilder.GetPaymentSessionsRequest(request);
            var paymentResponse = await _apiBuild.PaymentSessionsClient().RequestPaymentSessions
                (paymentSessionRequest);
            return paymentResponse != null
                ? paymentSessionBuilder.GetGeneratedPaymentSessionResponse(paymentResponse)
                : null;
        }
    }
}