namespace Application.Dtos
{
    public class MoneyDto
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public MoneyDto(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}