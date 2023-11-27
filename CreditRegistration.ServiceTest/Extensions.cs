using Newtonsoft.Json;

namespace CreditRegistration.ServiceTest
{
    public static class Extensions
    {
        public static T Deserialize<T>(this HttpResponseMessage source)
        {

            var str = source.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(source.Content.ReadAsStringAsync().Result);
        }
    }
}
