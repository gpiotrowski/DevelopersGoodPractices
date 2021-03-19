namespace DGP.DesignPatterns.Factory
{
    public interface ILoyaltyPlatform
    {
        int GetAvailableCredits();
        void Pay(decimal orderValue);
    }
}
