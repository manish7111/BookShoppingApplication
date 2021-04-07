using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IOrderSummaryRepo
    {
        Task<int> CreateOrderSummary(OrderSummary summary);
        OrderSummary GetOrderSummaryDetails(int details);
    }
}
