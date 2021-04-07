using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IManager
{
    public interface IOrderSummaryManager
    {
        Task<int> CreateOrderSummary(OrderSummary summary);
        OrderSummary GetOrderSummaryDetails(int details);
    }
}
