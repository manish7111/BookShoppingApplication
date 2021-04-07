using BookStoreModelLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IManager
{
    public interface ICartManager
    {
        Task<int> AddBooksToCart(Cart books);
        List<BookCartResponse> GetAllCartBooks(int userId);
        Cart DeleteBookFromCart(int cartId);
        int GetCartCount(int userId);
        Cart UpdateCart(Cart cart);
    }
}
