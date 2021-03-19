using DGP.DesignPatterns.Facade.Models;

namespace DGP.DesignPatterns.Facade.Services
{
    public interface IAccountService
    {
        Account CreateAccount(string login);
    }
}