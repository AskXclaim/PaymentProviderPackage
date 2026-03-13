namespace Application.Dtos
{
    public class PaymentSessionDetailSourceDto
    {
        public string Id { get; private set; }
        public int? ExpiryMonth { get; private set; }
        public int? ExpireYear { get; private set; }
        public string Name { get; private set; }
        public string LastFourDigits { get; private set; }

        public PaymentSessionDetailSourceDto(
            string id, int? expiryMonth, int? expireYear, string name,
            string lastFourDigits)
        {
            Id = id;
            ExpiryMonth = expiryMonth;
            ExpireYear = expireYear;
            Name = name;
            LastFourDigits = lastFourDigits;
        }
    }
}