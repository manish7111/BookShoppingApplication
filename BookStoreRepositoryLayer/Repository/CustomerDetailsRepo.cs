using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.UserContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
    public class CustomerDetailsRepo : ICustomerDetailsRepo
    {
        public readonly BookDBContext context;
        public CustomerDetailsRepo(BookDBContext context)
        {
            this.context = context;
        }
        public Task<int> AddAddress(CustomerDetails details)
        {
            this.context.Address.Add(details);
            var result = this.context.SaveChangesAsync();
            return result;
        }
        public CustomerDetails UpdateAddress(CustomerDetails details)
        {
            var result = this.context.Address.Where<CustomerDetails>(selectedItem => selectedItem.UserId == details.UserId).FirstOrDefault();
            if (result != null)
            {
                result.FullName = details.FullName;
                result.Email = details.Email;
                result.ContactNumber = details.ContactNumber;
                result.DeliveryAddress = details.DeliveryAddress;
                result.ZipCode = details.ZipCode;
                result.CityTown = details.CityTown;
                result.LandMark = details.LandMark;
                result.AddressType = details.AddressType;
                this.context.Update(result);
                var updateResult = this.context.SaveChanges();
                if (updateResult >= 0)
                {
                    return result;
                }
            }           
            return null;
        }
        public CustomerDetails GetAddress(int details)
        {
            var result = this.context.Address.Where<CustomerDetails>(selectedItem => selectedItem.UserId == details).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
