using BookStoreModelLayer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.IRepository
{
    public interface IBookRepo
    {
        Task<int> AddBooks(Books books);
        IEnumerable<Books> GetAllBooks();
        string Image(IFormFile file, int id);
    }
}
