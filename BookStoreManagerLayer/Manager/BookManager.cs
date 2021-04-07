using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagerLayer.Manager
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepo bookRepo;
        public BookManager(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public Task<int> AddBooks(Books books)
        {
            var result = this.bookRepo.AddBooks(books);
            return result;
        }

        public IEnumerable<Books> GetAllBooks()
        {
            var result = this.bookRepo.GetAllBooks();
            return result;
        }

        public string Image(IFormFile file, int id)
        {
            var result = this.bookRepo.Image(file, id);
            return result;
        }
    }
}
