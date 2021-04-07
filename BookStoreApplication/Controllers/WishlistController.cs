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
    public class WishlistController : ControllerBase
    {
        public readonly IWishListManager wishListManager;
        public WishlistController(IWishListManager wishListManager)
        {
            this.wishListManager = wishListManager;
        }
        [HttpPost]
        public async Task<ActionResult> AddBooksToWishlist(WishList book)
        {
            try
            {
                int userId = TokenUserId();
                book.UserId = userId;
                var result = await this.wishListManager.AddBooksToWishlist(book);
                if (result == 1)
                {
                    return this.Ok(new { Status = true, Message = "Book Added to Wishlist Successfully", Data = book });
                }
                return this.BadRequest(new { Status = false, Message = "Book Added to Wishlist Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpDelete]
        [Route("{wishlistId}")]
        public ActionResult DeleteBookFromWishlist(int wishlistId)
        {
            try
            {
                var result = this.wishListManager.DeleteBookFromWishlist(wishlistId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Book Deleted from Wishlist Successfully", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Book Deleted from Wishlist Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpGet]
        public ActionResult GetAllWishlistBooks()
        {
            try
            {
                int userId = TokenUserId();
                var result = this.wishListManager.GetAllWishlistBooks(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "List of books added to Wishlist", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No books found" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpGet]
        [Route("GetWishlistBookCount")]
        public ActionResult CountOfBooksInWisslist()
        {
            try
            {
                int userId = TokenUserId();
                var result = this.wishListManager.GetWishlistCount(userId);
                if (result >= 0)
                {
                    return this.Ok(new { Status = true, Message = "Count of Books in Wishlist", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No books found" });
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