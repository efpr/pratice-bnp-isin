

namespace pratice_isin.Domain
{
    public interface ISecurityPricer
    {
        public decimal GetPrice(string isin);
    }
}
