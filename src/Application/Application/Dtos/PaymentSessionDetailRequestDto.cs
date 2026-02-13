namespace Application.Dtos
{
    public class PaymentSessionDetailRequestDto
    {
        public string PaymentSessionId { get;}

        public PaymentSessionDetailRequestDto(string paymentSessionId)
        {
            PaymentSessionId = paymentSessionId;
        }
    }
}