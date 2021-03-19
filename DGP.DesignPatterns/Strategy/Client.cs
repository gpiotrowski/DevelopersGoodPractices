using DGP.DesignPatterns.Strategy.Models;
using DGP.DesignPatterns.Strategy.RoutingStrategies;

namespace DGP.DesignPatterns.Strategy
{
    class Client
    {
        public void Execute()
        {
            var deliveryPlanner = new DeliveryPlanner();

            Location startLocation = new Location();
            Location endLocation = new Location();

            deliveryPlanner.SetRoutingStrategy(new FastRoutingStrategy());
            var fastDelivery = deliveryPlanner.PlanDelivery(startLocation, endLocation);

            deliveryPlanner.SetRoutingStrategy(new MinimalizeTurningLeftStrategy());
            var experimentalDelivery = deliveryPlanner.PlanDelivery(startLocation, endLocation);
        }
    }
}
