using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface ICustomerDetailsRepo
    {
        Task<int> AddAddress(CustomerDetails details);
        CustomerDetails UpdateAddress(CustomerDetails details);
        CustomerDetails GetAddress(int details);
    }
}
