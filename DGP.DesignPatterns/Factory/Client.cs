namespace DGP.DesignPatterns.Factory
{
    class Client
    {
        public void Execute()
        {
            var platformFactory = new LoyaltyPlatformFactory();

            var loyaltyPlatform = platformFactory.CreatePlatform(LoyaltyPlatformType.Customer);
            loyaltyPlatform.Pay(12.34M);
        }
    }
}
