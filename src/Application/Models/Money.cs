using Application.Enums;

namespace Application.Models
{
    public class Money
    {
        public decimal Amount { get; } 
        public Currency Currency { get; }
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}