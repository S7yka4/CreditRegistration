using CreditRegistrationService.Bodies;
using Newtonsoft.Json;
using System.Security.Authentication;
using System.Text;

namespace CreditRegistration.ServiceTest
{
    public class CreditRegistartionClient
    {
        HttpClient _client;

        public CreditRegistartionClient(string uri)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(uri);
        }

        public HttpResponseMessage GetTarrifs()
        {
            string path = "getTarrifs";
            return _client.GetAsync(path).Result;
        }

        public HttpResponseMessage GetException()
        {
            string path = "getException";
            return _client.GetAsync(path).Result;
        }

        public HttpResponseMessage GetStatusOrder(string orderId)
        {
            string path = "getStatusOrder";
            return _client.GetAsync(path).Result;
        }

        public HttpResponseMessage CreateOrder(long userId, long tarrifId)
        {
            var path = "order";
            var body = new CreateOrderRequest()
            {
                userId = userId,
                tarrifId = tarrifId
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return _client.PostAsync(path, content).Result;
        }

        public HttpResponseMessage DeleteOrder(long userId, string orderId)
        {
            var path = "deleteOrder";
            var body = new DeleteOrderRequest()
            {
                userId = userId,
                orderId = orderId
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_client.BaseAddress.ToString() + path),
                Content = content,
                Method = HttpMethod.Delete
            };
            return _client.SendAsync(request).Result;

        }
    }
}
