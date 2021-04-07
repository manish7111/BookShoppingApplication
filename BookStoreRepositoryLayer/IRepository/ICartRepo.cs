using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface ICartRepo
    {
        Task<int> AddBooksToCart(Cart books);
        List<BookCartResponse> GetAllCartBooks(int userId);
        Cart DeleteBookFromCart(int cartId);
        int GetCartCount(int userId);
        Cart UpdateCart(Cart cart);
    }
}
