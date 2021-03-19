using System.Collections.Generic;
using System.Linq;

namespace DGP.DesignPatterns.Composite.Models
{
    public class Order
    {
        public Address DeliveryAddress { get; set; }
        public decimal TotalCost => _orderLines.Sum(x => x.Product.Price * x.Quantity);

        private List<OrderLine> _orderLines { get; set; }

        public Order()
        {
            _orderLines = new List<OrderLine>();
        }

        public void AddProduct(Product product, int quantity)
        {
            _orderLines.Add(new OrderLine(product, quantity));
        }
    }
}
