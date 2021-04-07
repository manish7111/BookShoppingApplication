using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IManager
{
    public interface IWishListManager
    {
        Task<int> AddBooksToWishlist(WishList books);
        List<BookWishlistResponse> GetAllWishlistBooks(int userId);
        WishList DeleteBookFromWishlist(int wishlistId);
        int GetWishlistCount(int userId);
    }
}
