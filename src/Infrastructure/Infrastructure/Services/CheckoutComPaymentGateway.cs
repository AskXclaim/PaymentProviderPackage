using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using Checkout;
using Infrastructure.Services.Builders;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Factories.Interfaces;

namespace Infrastructure.Services
{
    public class CheckoutComPaymentGateway : IPaymentGateway
    {
        private readonly ICheckoutApi _apiBuild =
            new CheckoutApiBuilder("").GetApiBuild();

        private readonly IFactory _paymentFactory;

        public CheckoutComPaymentGateway() =>
            _paymentFactory = new CheckoutPaymentMethodFactory(_apiBuild);

        public async Task<GeneratedPaymentSessionResponse> GeneratePaymentSession(GeneratePaymentSessionRequest request) =>
            await _paymentFactory.GetResult(request) as GeneratedPaymentSessionResponse;

        public async Task<PaymentSessionDetailResponse> GetPaymentSessionDetails(PaymentSessionDetailRequest request) =>
            await _paymentFactory.GetResult(request) as PaymentSessionDetailResponse;
    }
}