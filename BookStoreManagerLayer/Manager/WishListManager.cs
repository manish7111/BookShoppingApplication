using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.Manager
{
    public class WishListManager : IWishListManager
    {
        private readonly IWishListRepo wishListRepo;
        public WishListManager(IWishListRepo wishListRepo)
        {
            this.wishListRepo = wishListRepo;
        }
        public Task<int> AddBooksToWishlist(WishList books)
        {
            var result = this.wishListRepo.AddBooksToWishlist(books);
            return result;
        }

        public WishList DeleteBookFromWishlist(int wishlistId)
        {
            var result = this.wishListRepo.DeleteBookFromWishlist(wishlistId);
            return result;
        }

        public List<BookWishlistResponse> GetAllWishlistBooks(int userId)
        {
            var result = this.wishListRepo.GetAllWishlistBooks(userId);
            return result;
        }

        public int GetWishlistCount(int userId)
        {
            var result = this.wishListRepo.GetWishlistCount(userId);
            return result;
        }
    }
}
