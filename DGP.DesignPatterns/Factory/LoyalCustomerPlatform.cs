using System;

namespace DGP.DesignPatterns.Factory
{
    public class LoyalCustomerPlatform : ILoyaltyPlatform
    {
        public int GetAvailableCredits()
        {
            Console.WriteLine("0 Customer Coins available!");
            return 0;
        }

        public void Pay(decimal orderValue)
        {
            Console.WriteLine("Payed using Customer Coins!");
        }
    }
}
