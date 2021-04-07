using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.UserContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
    public class CartRepo : ICartRepo
    {
        public readonly BookDBContext context;
        public CartRepo(BookDBContext context)
        {
            this.context = context;
        }
        public Task<int> AddBooksToCart(Cart books)
        {
            this.context.Cart.Add(books);
            var result = this.context.SaveChangesAsync();
            return result;
        }
        public List<BookCartResponse> GetAllCartBooks(int userId)
        {
            List<BookCartResponse> books = new List<BookCartResponse>();
            var cartData = this.context.Cart.Join(this.context.Books,
                Cart => Cart.BookId,
                Book => Book.BookId,
                (Cart, Book) =>
                new BookCartResponse
                {
                    BookId = Book.BookId,
                    BookTitle = Book.BookTitle,
                    AuthorName = Book.AuthorName,
                    Price = Book.Price,
                    BookImage = Book.BookImage,
                    BookCount = Book.BookCount,
                    SelectedBookCount = Cart.SelectedBookCount,
                    CartId = Cart.CartId,
                    UserId = Cart.UserId
                });
            foreach (var data in cartData)
            {
                if (data.UserId == userId)
                {
                    books.Add(data);
                }
            }
            return books;
        }
        public Cart DeleteBookFromCart(int cartId)
        {
            var cartModel = context.Cart.Find(cartId);
            if (cartModel != null)
            {
                context.Cart.Remove(cartModel);
                context.SaveChanges();
            }
            return cartModel;
        }
        public int GetCartCount(int userId)
        {
            var result = context.Cart.Where<Cart>(item => item.UserId == userId).ToList();
            return result.Count;
        }
        public Cart UpdateCart(Cart cart)
        {
            var result = this.context.Cart.Where<Cart>(selectedItem => selectedItem.CartId == cart.CartId).FirstOrDefault();
            result.SelectedBookCount = cart.SelectedBookCount;
            this.context.Update(result);
            var updateResult = this.context.SaveChanges();
            if (updateResult >= 0)
            {
                return result;
            }
            return null;
        }
    }
}
