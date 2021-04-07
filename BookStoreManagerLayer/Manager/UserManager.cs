using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo userRepo;
        public UserManager(IUserRepo userRepo)
        {
            this.userRepo = userRepo;

        }
        public User Login(Login login)
        {
            var result = this.userRepo.Login(login);
            return result;
        }

        public Task<int> Register(User user)
        {
            var result = this.userRepo.Register(user);
            return result;
        }
    }
}
