namespace CreditRegistrationService.Bodies
{
    public class CreateOrderRequest
    {
        public long userId { get; set; }
        public long tarrifId { get; set; }

        public CreateOrderRequest() { }
    }
}
