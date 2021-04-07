using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.Manager
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepo bookRepo;
        public CartManager(ICartRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }
        public Task<int> AddBooksToCart(Cart books)
        {
            var result = this.bookRepo.AddBooksToCart(books);
            return result;
        }

        public Cart DeleteBookFromCart(int cartId)
        {
            var result = this.bookRepo.DeleteBookFromCart(cartId);
            return result;
        }

        public List<BookCartResponse> GetAllCartBooks(int userId)
        {
            var result = this.bookRepo.GetAllCartBooks(userId);
            return result;
        }

        public int GetCartCount(int userId)
        {
            var result = this.bookRepo.GetCartCount(userId);
            return result;
        }

        public Cart UpdateCart(Cart cart)
        {
            var result = this.bookRepo.UpdateCart(cart);
            return result;
        }
    }
}
