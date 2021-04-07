using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.UserContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
    public class WishListRepo : IWishListRepo
    {
        public readonly BookDBContext context;
        public WishListRepo(BookDBContext context)
        {
            this.context = context;
        }
        public Task<int> AddBooksToWishlist(WishList books)
        {
            this.context.WishList.Add(books);
            var result = this.context.SaveChangesAsync();
            return result;
        }
        public List<BookWishlistResponse> GetAllWishlistBooks(int userId)
        {
            List<BookWishlistResponse> books = new List<BookWishlistResponse>();
            var wishlistData = this.context.WishList.Join(this.context.Books,
                WishList => WishList.BookId,
                Book => Book.BookId,
                (WishList, Book) =>
                new BookWishlistResponse
                {
                    BookId = Book.BookId,
                    BookTitle = Book.BookTitle,
                    AuthorName = Book.AuthorName,
                    Price = Book.Price,
                    BookImage = Book.BookImage,
                    WishListId = WishList.WishListId,
                    UserId = WishList.UserId
                });
            foreach (var data in wishlistData)
            {
                if (data.UserId == userId)
                {
                    books.Add(data);
                }
            }
            return books;
        }
        public WishList DeleteBookFromWishlist(int wishlistId)
        {
            var cartModel = context.WishList.Find(wishlistId);
            if (cartModel != null)
            {
                context.WishList.Remove(cartModel);
                context.SaveChanges();
            }
            return cartModel;
        }
        public int GetWishlistCount(int userId)
        {
            var result = context.WishList.Where<WishList>(item => item.UserId == userId).ToList();
            return result.Count;
        }
    }
}
