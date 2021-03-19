using System;
using System.Collections.Generic;
using System.Linq;

namespace DGP.CleanCode
{
    public class Comments
    { 
        // Comments could be replaced with method calls
        private void ProcessCustomerOrderBad(Guid customerId, Order order)
        {
            var customer = GetCustomer(customerId);
            var orders = GetCustomerOrders(customerId);

            // Check if client is eligible for free delivery
            if (customer.IsPremiumAccount || orders.Sum(x => x.TotalPrice) > 500)
            {
                order.FreeDelivery = true;
                order.DeliveryCost = 0;
            }
            else
            {
                order.FreeDelivery = false;
                order.DeliveryCost = 10M;
            }

            // Get value of discount
            var customerTotalSpending = orders.Sum(x => x.TotalPrice);
            var numberOfCustomerOrders = orders.Count;
            var percentageDiscountValue = 0;
            if (customerTotalSpending > 600 && numberOfCustomerOrders > 3)
            {
                var discountBasedOnTotalSpending = (int)Math.Floor(customerTotalSpending / 600);
                percentageDiscountValue = Math.Min(numberOfCustomerOrders, discountBasedOnTotalSpending);
            }

            // Apply discount
            order.PercentageDiscount = percentageDiscountValue;
            order.TotalPriceAfterDiscount = order.TotalPrice * (1 - percentageDiscountValue / 100M);

            SaveOrder(order);
        }

        // Could be refactored to
        private void ProcessCustomerOrder(Guid customerId, Order order)
        {
            var customer = GetCustomer(customerId);
            var orders = GetCustomerOrders(customerId);

            CalculateDeliveryCosts(customer, orders, order);

            var percentageDiscountValue = CalculateDiscountValue(orders);
            order.ApplyDiscount(percentageDiscountValue);

            SaveOrder(order);
        }

        private decimal CalculateDiscountValue(List<Order> orders)
        {
            var customerTotalSpending = orders.Sum(x => x.TotalPrice);
            var numberOfCustomerOrders = orders.Count;

            var percentageDiscountValue = 0;
            if (customerTotalSpending > 600 && numberOfCustomerOrders > 3)
            {
                var discountBasedOnTotalSpending = (int)Math.Floor(customerTotalSpending / 600);
                percentageDiscountValue = Math.Min(numberOfCustomerOrders, discountBasedOnTotalSpending);
            }

            return percentageDiscountValue;
        }

        private void CalculateDeliveryCosts(Customer customer, List<Order> orders, Order newOrder)
        {
            if (IsEligibleForFreeDelivery(customer, orders))
            {
                newOrder.FreeDelivery = true;
                newOrder.DeliveryCost = 0;
            }
            else
            {
                newOrder.FreeDelivery = false;
                newOrder.DeliveryCost = 10M;
            }
        }

        private bool IsEligibleForFreeDelivery(Customer customer, List<Order> orders)
        {
            return customer.IsPremiumAccount || orders.Sum(x => x.TotalPrice) > 500;
        }

        private Customer GetCustomer(Guid customerId)
        {
            return new Customer();
        }

        private List<Order> GetCustomerOrders(Guid customerId)
        {
            return new List<Order>();
        }

        private void SaveOrder(Order order) { }

        private class Customer
        {
            public bool IsPremiumAccount { get; set; }
        }

        private class Order
        {
            public decimal TotalPrice { get; set; }
            public decimal PercentageDiscount { get; set; }
            public decimal TotalPriceAfterDiscount { get; set; }
            public bool FreeDelivery { get; set; }
            public decimal DeliveryCost { get; set; }

            public void ApplyDiscount(decimal percentageDiscountValue)
            {
                PercentageDiscount = percentageDiscountValue;
                TotalPriceAfterDiscount = TotalPrice * (1 - percentageDiscountValue / 100M);
            }
        }
    }
}
