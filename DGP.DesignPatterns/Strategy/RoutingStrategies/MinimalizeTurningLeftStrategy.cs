using DGP.DesignPatterns.Strategy.Models;

namespace DGP.DesignPatterns.Strategy.RoutingStrategies
{
    public class MinimalizeTurningLeftStrategy : IRoutingStrategy
    {
        public Route GenerateRoute(Location startLocation, Location endLocation)
        {
            // Algorithm that will create route that minimalize turning left
            return new Route();
        }
    }
}