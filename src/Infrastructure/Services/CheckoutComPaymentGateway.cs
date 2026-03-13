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

        public async Task<GeneratedPaymentSessionResponseDto> GeneratePaymentSession(GeneratePaymentSessionRequestDto requestDto) =>
            await _paymentFactory.GetResult(requestDto) as GeneratedPaymentSessionResponseDto ;
        
        public async Task<PaymentSessionDetailResponseDto> GetPaymentSessionDetails(PaymentSessionDetailRequestDto requestDto) =>
            await _paymentFactory.GetResult(requestDto) as PaymentSessionDetailResponseDto;
    }
}