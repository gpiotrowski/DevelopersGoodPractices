using DGP.DesignPatterns.Strategy.Models;

namespace DGP.DesignPatterns.Strategy.RoutingStrategies
{
    public interface IRoutingStrategy
    {
        Route GenerateRoute(Location startLocation, Location endLocation);
    }
}
