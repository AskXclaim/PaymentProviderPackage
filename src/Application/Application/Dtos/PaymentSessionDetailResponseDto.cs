using System;
using Application.Enums;

namespace Application.Dtos
{
    public class PaymentSessionDetailResponseDto
    {
        public string Id { get; private set; }
        public DateTime? RequestedOn { get; private set; }

        public PaymentSessionDetailSourceDto PaymentSessionDetailSource { get; private set; }
        public string PaymentType { get; private set; }
        public MoneyDto Amount { get; private set; }
        public string Reference { get; private set; }
        public string Description { get; private set; }
        public bool? IsApproved { get; private set; }
        public string Status { get; private set; }
        public PaymentSessionCustomerDto Customer { get; private set; }

        public PaymentSessionDetailResponseDto(string id, DateTime? requestedOn,
            PaymentSessionDetailSourceDto paymentSessionDetailSource, string paymentType,
            MoneyDto amount, string reference, string description, bool? isApproved,
            string status, PaymentSessionCustomerDto customer)
        {
            Id = id;
            RequestedOn = requestedOn;
            PaymentSessionDetailSource = paymentSessionDetailSource;
            PaymentType = paymentType;
            Amount = amount;
            Reference = reference;
            Description = description;
            IsApproved = isApproved;
            Status = status;
            Customer = customer;
        }
    }
}