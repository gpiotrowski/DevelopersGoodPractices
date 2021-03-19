using System;

namespace DGP.DesignPatterns.Decorator
{
    class Client
    {
        public void Execute()
        {
            var userRepository = new UserRepository();
            IUserRepository inMemoryUserRepository = new InMemoryCacheUserRepository(userRepository);

            var userId = Guid.NewGuid();

            // Each execution give different result - user is created each time with random name
            Console.WriteLine(userRepository.GetUser(userId).Name);
            Console.WriteLine(userRepository.GetUser(userId).Name);
            Console.WriteLine(userRepository.GetUser(userId).Name);

            // But we could use our in-memory cache
            // First call will create new user (will call base implementation)
            Console.WriteLine(inMemoryUserRepository.GetUser(userId).Name);
            // Other calls will get user from cache
            Console.WriteLine(inMemoryUserRepository.GetUser(userId).Name);
            Console.WriteLine(inMemoryUserRepository.GetUser(userId).Name);
        }
    }
}
