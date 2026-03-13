using System.Collections.Generic;
using System.Linq;
using Application.Dtos;
using Application.Enums;
using Checkout.Common;
using Checkout.Payments;
using Checkout.Payments.Request;
using Checkout.Payments.Sessions;
using Infrastructure.Services.Validators;
using Currency = Checkout.Common.Currency;
using Link = Application.Dtos.Link;
using PaymentType = Checkout.Payments.PaymentType;

namespace Infrastructure.Services.Builders
{
    public static class PaymentSessionBuilder
    {
        private const string CountryCode = "44";

        public static PaymentSessionsRequest GetPaymentSessionsRequest
            (IGeneratePaymentSessionRequest request)
        {
            return new PaymentSessionsRequest
            {
                Amount = (long)request.Amount,
                Currency = GlobalMethods.ParseEnum<Currency>(request.Currency.ToString()),              
                Billing = new BillingInformation
                {
                    Address = new Address
                    {
                        Country = PaymentSessionValidator.GetCountryCode(request.BillingDetails.Address.Country),
                        AddressLine1 = request.BillingDetails.Address.AddressLineOne,
                        AddressLine2 = request.BillingDetails.Address.AddressLineTwo,
                        City = request.BillingDetails.Address.City,
                        Zip = request.BillingDetails.Address.PostalCode
                    },
                    Phone = new Phone
                    {
                        CountryCode = CountryCode,
                        Number = request.BillingDetails.Phone
                    }
                },
                ThreeDs = new ThreeDsRequest
                {
                    Enabled = true,
                    ChallengeIndicator = ChallengeIndicatorType.ChallengeRequestedMandate
                },
                PaymentMethodConfiguration = new PaymentMethodConfiguration
                {
                    Card = new Card
                    {
                        StorePaymentDetails = StorePaymentDetailsType.Enabled
                    }
                },
                EnabledPaymentMethods = GetPaymentMethodsType(request.EnabledPaymentMethods),
                Customer = new PaymentCustomerRequest
                {
                    Name = $"{request.Customer.FirstName} {request.Customer.LastName}",
                    Email = request.Customer.Email
                },
                ProcessingChannelId = request.ProcessingChannelId,
                PaymentType = GlobalMethods.ParseEnum<PaymentType>(request.PaymentType.ToString()),
                SuccessUrl = request.SuccessUrl,
                FailureUrl = request.FailureUrl
            };
        }

        private static IList<PaymentMethodsType> GetPaymentMethodsType(IEnumerable<PaymentMethod> paymentMethodsTypes)
        {
            var checkoutPaymentMethodsTypes =
                paymentMethodsTypes.Select(paymentMethodsType =>
                    GlobalMethods.ParseEnum<PaymentMethodsType>(paymentMethodsType.ToString())).ToList();
            return checkoutPaymentMethodsTypes;
        }      

        public static GeneratedPaymentSessionResponseDto GetGeneratedPaymentSessionResponse(
            PaymentSessionsResponse paymentResponse)
        {
            var response = new GeneratedPaymentSessionResponseDto
            {
                PaymentSession = new PaymentSession
                {
                    Id = paymentResponse.Id,
                    PaymentSessionSecret = paymentResponse.PaymentSessionSecret,
                    PaymentSessionToken = paymentResponse.PaymentSessionToken,
                    Links = new Dictionary<string, Link>()
                }
            };
            foreach (var link in paymentResponse.Links)
            {
                response.PaymentSession.Links.Add(link.Key, new Link
                {
                    Href = link.Value.Href, Title = link.Value.Title
                });
            }

            return response;
        }
    }
}