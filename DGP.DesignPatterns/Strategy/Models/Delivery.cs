using DGP.DesignPatterns.Strategy.RoutingStrategies;

namespace DGP.DesignPatterns.Strategy.Models
{
    public class Delivery
    {
        public Route Route { get; set; }
        public decimal Cost { get; set; }
        public Courier Courier { get; set; }
    }
}