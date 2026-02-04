namespace Application.Dtos
{
    public class PaymentSessionDetailRequest
    {
        public string PaymentSessionId { get;}

        public PaymentSessionDetailRequest(string paymentSessionId)
        {
            PaymentSessionId = paymentSessionId;
        }
    }
}