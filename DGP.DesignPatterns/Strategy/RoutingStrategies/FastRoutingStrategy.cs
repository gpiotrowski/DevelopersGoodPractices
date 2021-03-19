using DGP.DesignPatterns.Strategy.Models;

namespace DGP.DesignPatterns.Strategy.RoutingStrategies
{
    public class FastRoutingStrategy : IRoutingStrategy
    {
        public Route GenerateRoute(Location startLocation, Location endLocation)
        {
            // Algorithm that will maximise route time efficiency
            return new Route();
        }
    }
}