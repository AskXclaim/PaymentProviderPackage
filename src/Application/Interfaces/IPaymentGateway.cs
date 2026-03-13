using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Interfaces
{
    public interface IPaymentGateway
    {     
        Task<GeneratedPaymentSessionResponseDto> GeneratePaymentSession(GeneratePaymentSessionRequestDto  requestDto);
        Task<PaymentSessionDetailResponseDto> GetPaymentSessionDetails(PaymentSessionDetailRequestDto requestDto);
    }
}