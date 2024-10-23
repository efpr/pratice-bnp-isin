using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pratice_isin.Domain.Exceptions
{
    public class FailToGetPriceException : Exception
    {
        private const string message = "Fail to get price";

        public FailToGetPriceException() : base(message)
        {
        }
    }
}
