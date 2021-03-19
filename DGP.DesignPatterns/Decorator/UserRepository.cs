using System;
using DGP.DesignPatterns.Decorator.Models;

namespace DGP.DesignPatterns.Decorator
{
    public class UserRepository : IUserRepository
    {
        Random _rand = new Random();

        public User GetUser(Guid id)
        {
            return new User(id, $"user_{_rand.Next(0, 10000)}");
        }
    }
}