using System.Threading.Tasks;
using Application.Dtos;

namespace Application.Interfaces
{
    public interface IPaymentGateway
    {
        Task<GeneratedPaymentSessionResponse> GeneratePaymentSession(GeneratePaymentSessionRequest  request);
        Task<GeneratedPaymentSessionRawResponse> GenerateRawPaymentSession(GenerateRawPaymentSessionRequest  request);
        Task<PaymentSessionDetailResponse> GetPaymentSessionDetails(PaymentSessionDetailRequest request);
    }
}