namespace DGP.DesignPatterns.Facade.Services
{
    public interface ILoginGenerator
    {
        string GenerateLogin(string name, string surname);
    }
}