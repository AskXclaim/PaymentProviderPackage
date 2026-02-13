namespace Application.Dtos
{
    public class GeneratedPaymentSessionResponseDto
    {
        public string Id { get; }
        public string Token { get; }
        public string Secret { get; }
        public string Href { get; }

        public GeneratedPaymentSessionResponseDto()
        {
        }   

        public GeneratedPaymentSessionResponseDto(string id, string token, string secret, string href)
        {
            Id = id;
            Token = token;
            Secret = secret;
            Href = href;
        }
    }
}