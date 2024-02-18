using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPExample.Solution
{
    public class DefaultPriceCalculator : IPriceCalculator
    {
        private readonly IEnumerable<IPriceStrategy> _priceStrategies;
        public DefaultPriceCalculator(IEnumerable<IPriceStrategy> priceStrategies)
        {
            _priceStrategies = priceStrategies;
        }
        public decimal CalculatePrice(OrderItem item)
        {
            return _priceStrategies.First(r => r.IsMatch(item)).CalculatePrice(item);
        }
    }
}
