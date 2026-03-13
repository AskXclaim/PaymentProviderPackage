namespace Application.Dtos
{
    public class PaymentSessionCustomerDto
    {
        public string Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }

        public PaymentSessionCustomerDto(string id, string email, string name)
        {
            Id = id;
            Email = email;
            Name = name;
        }
    }
}