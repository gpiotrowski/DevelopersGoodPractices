using System;

namespace DGP.DesignPatterns.Factory
{
    public class LoyaltyPlatformFactory
    {
        public ILoyaltyPlatform CreatePlatform(LoyaltyPlatformType platformType)
        {
            switch (platformType)
            {
                case LoyaltyPlatformType.Employee:
                    return new EmployeeBenefitPlatform();
                case LoyaltyPlatformType.Customer:
                    return new LoyalCustomerPlatform();
                default:
                    throw new Exception();
            }
        }
    }

    public enum LoyaltyPlatformType
    {
        Employee,
        Customer
    }
}
