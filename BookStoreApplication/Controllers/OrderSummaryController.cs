using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class OrderSummaryController : ControllerBase
    {
        public readonly IOrderSummaryManager manager;
        public OrderSummaryController(IOrderSummaryManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        public async Task<ActionResult> CreateOrderSummary(OrderSummary summary)
        {
            try
            {
                int userId = TokenUserId();
                summary.UserId = userId;
                var result = await this.manager.CreateOrderSummary(summary);
                if (result == 1)
                {
                    return this.Ok(new { Status = true, Message = "Order Summary Created Successfully", Data = summary });
                }
                return this.BadRequest(new { Status = false, Message = "Book Added to Wishlist Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpGet]
        public ActionResult GetOrderSummary()
        {
            try
            {
                int userId = TokenUserId();
                var result = this.manager.GetOrderSummaryDetails(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Order Summary Details Found", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No Records Found" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        private int TokenUserId()
        {
            return Convert.ToInt32(User.FindFirst("userId").Value);
        }
    }
}