using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONExample.model
{
    public class Address
    {
        public string? Street { get; set; }
        public string? Suite { get; set; }
        public string? City { get; set; }
        public string? Zipcode { get; set; }
        public Geo? Geo { get; set; }

        public override string ToString()
        {
            return $"Street: {Street} Suite: {Suite} City: {City} Zipcode: {Zipcode} Geo: {Geo}";
        }
    }
}
