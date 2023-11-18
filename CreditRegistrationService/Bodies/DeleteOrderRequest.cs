namespace CreditRegistrationService.Bodies
{
    public class DeleteOrderRequest
    {
        public long userId { get; set; }
        public string orderId { get; set; }
        public DeleteOrderRequest() { }
    }
}
