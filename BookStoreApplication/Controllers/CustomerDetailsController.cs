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
    public class CustomerDetailsController : ControllerBase
    {
        public readonly ICustomerDetailsManager manager;
        public CustomerDetailsController(ICustomerDetailsManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        public async Task<ActionResult> AddAddress(CustomerDetails details)
        {
            try
            {
                int userId = TokenUserId();
                details.UserId = userId;
                var result = await this.manager.AddAddress(details);
                if (result == 1)
                {
                    return this.Ok(new { Status = true, Message = "Customer details Added Successfully", Data = details });
                }
                return this.BadRequest(new { Status = false, Message = "Customer details Added Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpPut]
        public ActionResult UpdateAddress(CustomerDetails details)
        {
            try
            {
                int userId = TokenUserId();
                details.UserId = userId;
                var result = this.manager.UpdateAddress(details);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Address updated successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Address update Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpGet]
        public ActionResult GetAddress()
        {
            try
            {
                int userId = TokenUserId();
                var result = this.manager.GetAddress(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Customer Details found", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No records found" });
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