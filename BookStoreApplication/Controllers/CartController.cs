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
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;
        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }
        [HttpPost]
        public async Task<ActionResult> AddBooksToCart(Cart book)
        {
            try
            {
                int userId = TokenUserId();
                book.UserId = userId;
                var result = await this.cartManager.AddBooksToCart(book);
                if (result == 1)
                {
                    return this.Ok(new { Status = true, Message = "Book Added to Cart Successfully", Data = book });
                }
                return this.BadRequest(new { Status = false, Message = "Book Added to Cart Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpDelete]
        [Route("{cartId}")]
        public ActionResult DeleteBookFromCart(int cartId)
        {
            try
            {
                var result = this.cartManager.DeleteBookFromCart(cartId);
                if (result!=null)
                {
                    return this.Ok(new { Status = true, Message = "Book Deleted from Cart Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Book Deleted from Cart Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            try
            {
                int userId = TokenUserId();
                var result = this.cartManager.GetAllCartBooks(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "List of books added to cart", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No books found" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpGet]
        [Route("GetCountOfBooksInCart")]
        public ActionResult CountOfBooksInCart()
        {
            try
            {
                int userId = TokenUserId();
                var result = this.cartManager.GetCartCount(userId);
                if (result >= 0)
                {
                    return this.Ok(new { Status = true, Message = "Count of Books in Cart", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No books found" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpPut]
        public ActionResult UpdateBookInCart(Cart cart)
        {
            try
            {
                int userId = TokenUserId();
                cart.UserId = userId;
                var result = this.cartManager.UpdateCart(cart);
                if (result !=null)
                {
                    return this.Ok(new { Status = true, Message = "Cart updated successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Cart update Un-Successful" });
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