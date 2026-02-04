using Checkout;
using Environment = Checkout.Environment;

namespace Infrastructure.Services.Builders
{
    public class CheckoutApiBuilder
    {
        private readonly string _secretKey;
        private readonly string _publicKey;
        private readonly Environment _environment;

        public CheckoutApiBuilder(
            string secretKey,
            string publicKey = null,
            Environment environment = Environment.Sandbox)
        {
            _secretKey = secretKey;
            _publicKey = publicKey;
            _environment = environment;
        }

        public ICheckoutApi GetApiBuild()
        {
            if (string.IsNullOrEmpty(_publicKey))
            {
                return CheckoutSdk.Builder().StaticKeys()
                    .PublicKey(_publicKey)
                    .SecretKey(_secretKey)
                    .Environment(_environment)
                    .HttpClientFactory(new DefaultHttpClientFactory())
                    .Build();
            }

            return CheckoutSdk.Builder().StaticKeys()
                .SecretKey(_secretKey)
                .Environment(_environment)
                .HttpClientFactory(new DefaultHttpClientFactory())
                .Build();
        }
    }
}