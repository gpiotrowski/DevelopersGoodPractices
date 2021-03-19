using DGP.DesignPatterns.Strategy.Models;
using DGP.DesignPatterns.Strategy.RoutingStrategies;

namespace DGP.DesignPatterns.Strategy
{
    public class DeliveryPlanner
    {
        private IRoutingStrategy _routingStrategy;

        public void SetRoutingStrategy(IRoutingStrategy routingStrategy)
        {
            _routingStrategy = routingStrategy;
        }

        public Delivery PlanDelivery(Location startLocation, Location endLocation)
        {
            var route = _routingStrategy.GenerateRoute(startLocation, endLocation);

            return new Delivery()
            {
                Route = route,
                Cost = CalculateCost(),
                Courier = PickCourier()
            };
        }

        private decimal CalculateCost() => 0M;
        private Courier PickCourier() => new Courier();
    }
}