

using pratice_isin.Domain;
using pratice_isin.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace pratice_isin.Application
{
    public class IsinPricer : IIsinPricer
    {

        private readonly ISecurityPricer _securityPricer;
        private readonly IRepository _repository;

        private const string isinValidator = "^[a-zA-Z0-9]{12}$";

        public IsinPricer(ISecurityPricer securityPricer, IRepository repository)
        {
            _securityPricer = securityPricer;
            _repository = repository;
        }

        public void GetPriceForISINAndSave(string[] isins)
        {
            try
            {
                GetPriceForISNSListAndSave(isins);
            }
            catch(FailToGetPriceException)
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        #region helpers

        private bool CheckISNSCode(string code)
        {
            var regex = new Regex(isinValidator);

            return regex.IsMatch(code);
        }


        private void GetPriceForISNSListAndSave(string[] isins)
        {
            foreach (var isin in isins)
            {
                CheckIfCodeISValid(isin);

                GetPriceAndSave(isin);
            }
        }

        private void CheckIfCodeISValid(string isin)
        {
            var isCodeValid = CheckISNSCode(isin);
            if (!isCodeValid)
            {
                throw new InvalidCodeException();
            }
        }

        private void GetPriceAndSave(string isinCode)
        {
            var price = _securityPricer.GetPrice(isinCode);

            var isin = new ISIN(isinCode, price);
            _repository.AddISIN(isin);
        }

        #endregion
    }
}
