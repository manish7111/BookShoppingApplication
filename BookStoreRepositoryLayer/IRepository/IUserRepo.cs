using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IUserRepo
    {
        Task<int> Register(User user);
        User Login(Login login);
    }
}
