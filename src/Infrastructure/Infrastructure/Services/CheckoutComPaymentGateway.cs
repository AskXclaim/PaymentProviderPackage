using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using Infrastructure.Services.Builders;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Factories.Interfaces;

namespace Infrastructure.Services
{
    public class CheckoutComPaymentGateway : IPaymentGateway
    {
        private readonly IFactory _paymentFactory;

        public CheckoutComPaymentGateway(string secretKey)
        {
            var apiBuild = new CheckoutApiBuilder(secretKey).GetApiBuild();
            _paymentFactory = new CheckoutPaymentMethodFactory(apiBuild);
        }

        public async Task<GeneratedPaymentSessionResponse> GeneratePaymentSession(GeneratePaymentSessionRequest request) =>
            await _paymentFactory.GetResult(request) as GeneratedPaymentSessionResponse;

        public async Task<PaymentSessionDetailResponse> GetPaymentSessionDetails(PaymentSessionDetailRequest request) =>
            await _paymentFactory.GetResult(request) as PaymentSessionDetailResponse;
    }
}