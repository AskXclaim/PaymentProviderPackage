using System.Collections.Generic;
using Application.Enums;
using Application.Models;

namespace Application.Dtos
{
    public interface IGeneratePaymentSessionRequest
    {
        string ProcessingChannelId { get; }
        Models.Money Money { get; }
        BillingDetails BillingDetails { get; }
        string SuccessUrl { get; }
        string FailureUrl { get; }

        PaymentType PaymentType { get; set; }
        /*
        string <= 50 characters
        A reference you can use to identify the payment. For example, an order number.

        For Amex payments, this must be at most 30 characters.
        For Benefit payments, the reference must be a unique alphanumeric value.
        For iDEAL payments, the reference is required and must be an alphanumeric value with a 35-character limit.
        */
        string Reference { get; }
        BillingDescriptor BillingDescriptor { get; }
        Customer Customer { get; }
        string DisplayName { get; }
        Locale Locale { get; }
        bool Enable3Ds { get; }
        IEnumerable<PaymentMethod> EnabledPaymentMethods { get; set; }
    }
}