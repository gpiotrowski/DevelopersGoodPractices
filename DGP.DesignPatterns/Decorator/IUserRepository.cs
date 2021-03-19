using System;
using DGP.DesignPatterns.Decorator.Models;

namespace DGP.DesignPatterns.Decorator
{
    public interface IUserRepository
    {
        User GetUser(Guid id);
    }
}