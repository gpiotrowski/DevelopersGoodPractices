using System;
using System.Collections.Generic;
using System.Linq;
using DGP.DesignPatterns.Decorator.Models;

namespace DGP.DesignPatterns.Decorator
{
    public class InMemoryCacheUserRepository : IUserRepository
    {
        private readonly IUserRepository _userRepository;

        private readonly List<User> _cachedUsers = new List<User>();

        public InMemoryCacheUserRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(Guid id)
        {
            var cachedUser = _cachedUsers.SingleOrDefault(x => x.Id == id);

            if (cachedUser == null)
            {
                var user = _userRepository.GetUser(id);
                _cachedUsers.Add(user);

                return user;
            }

            return cachedUser;
        }
    }
}