using System.Collections.Generic;
using Newtonsoft.Json;

namespace Application.Dtos
{
    public class GeneratedPaymentSessionResponseDto
    {
        public PaymentSession PaymentSession { get; set; }
    }

    public class Link
    {
        [JsonProperty(PropertyName = "href")]
        public string Href { get; set; }
        [JsonProperty(PropertyName = "title")]
        public object Title { get; set; }
    }

    public class PaymentSession
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "payment_session_token")]
        public string PaymentSessionToken { get; set; }
        [JsonProperty(PropertyName = "payment_session_secret")]
        public string PaymentSessionSecret { get; set; }

        [JsonProperty(PropertyName = "_links")]
        public IDictionary<string, Link> Links { get; set; }
    }
}