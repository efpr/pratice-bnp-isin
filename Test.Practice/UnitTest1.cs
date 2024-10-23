using pratice_isin.Application;
using pratice_isin.Domain;
using pratice_isin.Infrastructure;

namespace Test.Practice
{

    public class Practice
    {
        private readonly IRepository _repository;
        private readonly ISecurityPricer _securityPricer;
        private readonly IIsinPricer _isinPricer;

        public Practice()
        {
            _repository = new Repository();

            var httpClient = new HttpClient();
            _securityPricer = new SecurityPricer(httpClient);

            _isinPricer = new IsinPricer(_securityPricer, _repository);
        }

        [Theory]
        [InlineData(["asdd", "asdasd"])]
        public void Given_a_list_ISIN_When_I_send_the_List_Then_should_save(string[] isins)
        {;

            try
            {
                _isinPricer.GetPriceForISINAndSave(isins);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


    }
}