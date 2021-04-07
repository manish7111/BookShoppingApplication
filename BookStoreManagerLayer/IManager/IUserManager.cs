using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IManager
{
    public interface IUserManager
    {
        Task<int> Register(User user);
        User Login(Login login);
    }
}
