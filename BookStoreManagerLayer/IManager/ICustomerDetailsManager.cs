using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IManager
{
    public interface ICustomerDetailsManager
    {
        Task<int> AddAddress(CustomerDetails details);
        CustomerDetails UpdateAddress(CustomerDetails details);
        CustomerDetails GetAddress(int details);
    }
}
