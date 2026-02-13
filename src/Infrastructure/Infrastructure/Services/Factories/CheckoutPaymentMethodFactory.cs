using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Exceptions;
using Checkout;
using Infrastructure.Services.Factories.FactoryItems;
using Infrastructure.Services.Factories.Interfaces;

namespace Infrastructure.Services.Factories
{
    public class CheckoutPaymentMethodFactory : IFactory
    {
        private readonly ICheckoutApi _apiBuilder;

        public CheckoutPaymentMethodFactory(ICheckoutApi apiBuilder)
        {
            _apiBuilder = apiBuilder;
        }

        public async Task<object> GetResult(object request)
        {
            try
            {
                switch (request.GetType().Name)
                {
                    case nameof(GeneratePaymentSessionRequestDto):
                        var generatePaymentSession = new GeneratePaymentSession(_apiBuilder);
                        return await generatePaymentSession.GetResult((GeneratePaymentSessionRequestDto)request);
                    case nameof(GenerateRawPaymentSessionRequestDto):
                        var aGeneratePaymentSession = new GeneratePaymentSession(_apiBuilder);
                        return await aGeneratePaymentSession.GetResult((GenerateRawPaymentSessionRequestDto)request);
                    case nameof(PaymentSessionDetailRequestDto):
                        var getPaymentSessionDetails = new GetPaymentSessionDetails(_apiBuilder);
                        return await getPaymentSessionDetails.GetResult(((PaymentSessionDetailRequestDto)request)
                            .PaymentSessionId);
                    default:
                        throw new PaymentProviderException($"Unknown request type {request.GetType().Name}",
                            HttpStatusCode.InternalServerError);
                }
            }
            // Todo: We may want to treat each exception differently
            catch (CheckoutApiException exception)
            {
                throw new PaymentProviderException(GetErrorContent(exception), exception.HttpStatusCode);
            }
            catch (CheckoutArgumentException exception)
            {
                throw new PaymentProviderException(exception.Message, HttpStatusCode.InternalServerError);
            }
            catch (CheckoutAuthorizationException exception)
            {
                throw new PaymentProviderException(exception.Message, HttpStatusCode.Unauthorized);
            }
            catch (PaymentProviderException exception)
            {
                throw new PaymentProviderException(exception.Message, exception.HttpStatusCode);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private string GetErrorContent(CheckoutApiException exception)
        {
            var value = exception.ErrorDetails["error_codes"].ToString().Split('"')
                .First(s => !string.IsNullOrWhiteSpace(s) && !s.Contains("[") && !s.Contains("]"));

            return $"{exception.ErrorDetails["error_type"].ToString().Trim()}: '{value}'";
        }
    }
}