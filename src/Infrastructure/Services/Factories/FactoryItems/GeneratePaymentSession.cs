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

        private async Task<PaymentSessionsResponse> GetPaymentSession(IGeneratePaymentSessionRequest request)
        {
            if (!PaymentSessionValidator.IsCurrencyValid(request.Currency))
                throw new PaymentProviderException($"Invalid currency '{request.Currency.ToString()}'" +
                                                   " provided", HttpStatusCode.BadRequest);

            var paymentSessionRequest = PaymentSessionBuilder.GetPaymentSessionsRequest(request);
            var paymentResponse = await _apiBuild.PaymentSessionsClient().RequestPaymentSessions
                (paymentSessionRequest);
            return paymentResponse;
        }

        public async Task<GeneratedPaymentSessionResponseDto> GetResult(GeneratePaymentSessionRequestDto requestDto)
        {
             var paymentResponse = await GetPaymentSession(requestDto);
             return paymentResponse != null
                 ? PaymentSessionBuilder.GetGeneratedPaymentSessionResponse(paymentResponse)
                 : null;
        }
    }
}