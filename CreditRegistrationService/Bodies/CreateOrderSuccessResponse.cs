namespace CreditRegistrationService.Bodies
{
    public class Data
    {
        public string orderId { get; set; }
        public Data() { }
        public Data(string _orderId)
        {
            orderId = _orderId;
        }
    }
    public class CreateOrderSuccessResponse
    {
        public Data data { get; set; }

        public CreateOrderSuccessResponse()
        {
        }
        public CreateOrderSuccessResponse(string orderId) 
        {
            data = new Data(orderId);
        }
    }
}
