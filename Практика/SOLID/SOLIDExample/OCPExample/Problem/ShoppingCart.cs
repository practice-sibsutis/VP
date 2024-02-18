using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPExample.Problem
{
    public class ShoppingCart
    {
        private readonly List<OrderItem> _orderItems;
        public ShoppingCart()
        {
            _orderItems = new List<OrderItem>();
        }
        public IEnumerable<OrderItem> OrderItems
        {
            get { return _orderItems; }
        }
        public string CustomerEmail { get; set; }
        public void Add(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
        }
        public decimal TotalAmount()
        {
            decimal total = 0m;
            foreach (OrderItem orderItem in OrderItems)
            {
                if (orderItem.Identifier.StartsWith("Each"))
                {
                    total += orderItem.Quantity * 4m;
                }
                else if (orderItem.Identifier.StartsWith("Weight"))
                {
                    total += orderItem.Quantity * 3m / 1000; //1 kilogram
                }
                else if (orderItem.Identifier.StartsWith("Spec"))
                {
                    total += orderItem.Quantity * .3m;
                    int setsOfFour = orderItem.Quantity / 4;
                    total -= setsOfFour * .15m; //discount on groups of 4 items
                }
            }
            return total;
        }
    }
}
