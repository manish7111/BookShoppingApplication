using BookStoreModelLayer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.IManager
{
    public interface IBookManager
    {
        Task<int> AddBooks(Books books);
        IEnumerable<Books> GetAllBooks();
        string Image(IFormFile file, int id);
    }
}
