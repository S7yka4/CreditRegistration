namespace CreditRegistrationService.Bodies
{
    public class DeleteOrderRequest
    {
        public long userId { get; init; }
        public string orderId { get; init; }
    }
}
