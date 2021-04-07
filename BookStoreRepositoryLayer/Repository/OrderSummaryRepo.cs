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
    public class OrderSummaryRepo : IOrderSummaryRepo
    {
        public readonly BookDBContext context;
        public OrderSummaryRepo(BookDBContext context)
        {
            this.context = context;
        }
        public Task<int> CreateOrderSummary(OrderSummary summary)
        {
            Random random = new Random();
            summary.OrderNumber = random.Next(100000, 999999).ToString();
            this.context.OrderSummary.Add(summary);
            var result = this.context.SaveChangesAsync();
            return result;
        }
        public OrderSummary GetOrderSummaryDetails(int details)
        {
            var result = this.context.OrderSummary.Where<OrderSummary>(selectedItem => selectedItem.UserId == details).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
