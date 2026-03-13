using System.Collections.Generic;
using Application.Enums;
using Application.Models;

namespace Application.Dtos
{
    public class GeneratePaymentSessionRequestDto:IGeneratePaymentSessionRequest
    {
        public string ProcessingChannelId { get; }
        public decimal Amount { get; }
        public Currency Currency { get; }
        public BillingDetails BillingDetails { get; }
        public string SuccessUrl { get; }
        public string FailureUrl { get; }

        //These are optional though I think would be really useful for us to have
        public PaymentType PaymentType { get; set; } = PaymentType.Unscheduled;

        //string <= 50 characters
        //A reference you can use to identify the payment. For example, an order number.
        public string Reference { get; }
        public BillingDescriptor BillingDescriptor { get; }
        public Customer Customer { get; }

        //string <= 255 characters. The merchant's display name.
        public string DisplayName { get; }
        public Locale Locale { get; }
        public bool Enable3Ds { get; }


        public IEnumerable<PaymentMethod> EnabledPaymentMethods { get; set; }
            = new List<PaymentMethod>
            {
                PaymentMethod.Card
            };

        public GeneratePaymentSessionRequestDto(
            string processingChannelId,
            BillingDetails billingDetails,
            decimal amount,
            Currency currency,
            string successUrl,
            string failureUrl,
            string reference,
            BillingDescriptor billingDescriptor,
            Customer customer,
            string displayName,
            Locale locale = Locale.EnGb,
            bool enable3Ds = true)
        {
            ProcessingChannelId = processingChannelId;
            BillingDetails = billingDetails;
            Amount = amount;
            Currency = currency;
            SuccessUrl = successUrl;
            FailureUrl = failureUrl;
            Reference = reference;
            BillingDescriptor = billingDescriptor;
            Customer = customer;
            DisplayName = displayName;
            Locale = locale;
            Enable3Ds = enable3Ds;
        }
    }
}