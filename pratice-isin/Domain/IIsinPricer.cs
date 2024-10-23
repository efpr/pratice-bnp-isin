
namespace pratice_isin.Domain
{
    public interface IIsinPricer
    {
        void GetPriceForISINAndSave(string[] isins);
    }
}
