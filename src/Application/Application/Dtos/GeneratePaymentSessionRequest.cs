using System.Collections.Generic;
using Application.Enums;
using Application.Models;

namespace Application.Dtos
{
    public class GeneratePaymentSessionRequest
    {
        public string ProcessingChannelId { get; }
        public Money Money { get; }
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

        public GeneratePaymentSessionRequest(
            string processingChannelId,
            BillingDetails billingDetails,
            Money money,
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
            Money = money;
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