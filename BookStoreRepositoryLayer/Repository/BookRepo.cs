using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using BookStoreRepositoryLayer.UserContext;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreRepositoryLayer.Repository
{
    public class BookRepo : IBookRepo
    {
        public readonly BookDBContext context;
        public BookRepo(BookDBContext context)
        {
            this.context = context;
        }
        public Task<int> AddBooks(Books books)
        {
            this.context.Books.Add(books);
            var result = this.context.SaveChangesAsync();
            return result;
        }
        public IEnumerable<Books> GetAllBooks()
        {
            var result = this.context.Books.ToList<Books>();
            return result;
        }
        //public Books UpdateBook(Books book)
        //{
        //    var result = this.context.Books.Where<Books>(selectedItem => selectedItem.BookId == book.BookId).FirstOrDefault();
        //    result.BookCount = book.BookCount-;
        //    this.context.Update(result);
        //    var updateResult = this.context.SaveChanges();
        //    if (updateResult >= 0)
        //    {
        //        return result;
        //    }
        //    return null;
        //}
        public string Image(IFormFile file, int id)
        {
            try
            {
                if (file == null)
                {
                    return null;
                }
                var stream = file.OpenReadStream();
                var name = file.FileName;
                Account account = new Account("bridgelabz", "528399974555442", "Ts5d5Nso2b5SA1OwNPFMIdtutg0");
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(name, stream)
                };
                ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);
                cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));
                var data = this.context.Books.Where(t => t.BookId == id).FirstOrDefault();
                data.BookImage = uploadResult.Uri.ToString();
                var result = this.context.SaveChanges();
                return data.BookImage;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
