using System;
using System.Net;

namespace Application.Exceptions
{
    public class PaymentProviderException : Exception

    {
        public string Content { get; }
        public HttpStatusCode? HttpStatusCode { get; }

        public PaymentProviderException(string errorContent, HttpStatusCode? statusCode, string content, HttpStatusCode? httpStatusCode) : base(errorContent)
        {
            Content = content;
            HttpStatusCode = httpStatusCode;
        }
    }
}