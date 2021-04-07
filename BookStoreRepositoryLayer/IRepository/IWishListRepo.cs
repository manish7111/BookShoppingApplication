using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IWishListRepo
    {
        Task<int> AddBooksToWishlist(WishList books);
        List<BookWishlistResponse> GetAllWishlistBooks(int userId);
        WishList DeleteBookFromWishlist(int wishlistId);
        int GetWishlistCount(int userId);
    }
}
