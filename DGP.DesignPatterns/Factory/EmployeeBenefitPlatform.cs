using System;

namespace DGP.DesignPatterns.Factory
{
    public class EmployeeBenefitPlatform : ILoyaltyPlatform
    {
        public int GetAvailableCredits()
        {
            Console.WriteLine("0 Employee Points available. Sorry!");
            return 0;
        }

        public void Pay(decimal orderValue)
        {
            Console.WriteLine("Payed using Employee Points!");
        }
    }
}
