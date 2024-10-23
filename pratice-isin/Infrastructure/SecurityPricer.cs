using pratice_isin.Domain;
using pratice_isin.Domain.Exceptions;

namespace pratice_isin.Infrastructure
{
    public class SecurityPricer : ISecurityPricer
    {
        private HttpClient _client;
        private const string baseUrl = "https://securities.dataprovider.com/securityprice/";

        public SecurityPricer(HttpClient client)
        {
            _client = client;
        }
        public decimal GetPrice(string isin)
        {
            try
            {
                _client.BaseAddress = new Uri(baseUrl);
                var response = _client.GetAsync(isin);

                if (!response.Status.Equals(200))
                {

                    throw new Exception();

                }

                var price = response.Result.Content.ToString();

                if (string.IsNullOrEmpty(price))
                {
                    throw new Exception();
                }

                return decimal.Parse(price);
            } 
            catch (Exception)
            {
                throw new FailToGetPriceException();
            }
        }
    }
}
