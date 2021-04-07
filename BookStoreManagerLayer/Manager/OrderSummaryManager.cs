using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.Manager
{
    public class OrderSummaryManager : IOrderSummaryManager
    {
        public readonly IOrderSummaryRepo orderSummary;
        public OrderSummaryManager(IOrderSummaryRepo orderSummary)
        {
            this.orderSummary = orderSummary;
        }
        public Task<int> CreateOrderSummary(OrderSummary summary)
        {
            var result = this.orderSummary.CreateOrderSummary(summary);
            return result;
        }

        public OrderSummary GetOrderSummaryDetails(int details)
        {
            var result = this.orderSummary.GetOrderSummaryDetails(details);
            return result;
        }
    }
}
