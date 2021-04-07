using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.Manager
{
    public class CustomerDetailsManager : ICustomerDetailsManager
    {
        public readonly ICustomerDetailsRepo customerDetailsRepo;
        public CustomerDetailsManager(ICustomerDetailsRepo customerDetailsRepo)
        {
            this.customerDetailsRepo = customerDetailsRepo;
        }
        public Task<int> AddAddress(CustomerDetails details)
        {
            var result = this.customerDetailsRepo.AddAddress(details);
            return result;
        }

        public CustomerDetails GetAddress(int details)
        {
            var result = this.customerDetailsRepo.GetAddress(details);
            return result;
        }

        public CustomerDetails UpdateAddress(CustomerDetails details)
        {
            var result = this.customerDetailsRepo.UpdateAddress(details);
            return result;
        }
    }
}
