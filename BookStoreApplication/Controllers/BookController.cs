using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookManager bookManager;
        public BookController(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }
        [HttpPost]
        public async Task<ActionResult> AddBooks(Books book)
        {
            try
            {
                var result = await this.bookManager.AddBooks(book);
                if (result == 1)
                {
                    return this.Ok(new { Status = true, Message = "Book Added Sucssesfull", Data = book });
                }
                return this.BadRequest(new { Status = false, Message = "Book Added Un-Sucssesfull" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            try
            {
                var result=this.bookManager.GetAllBooks();
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "List of books", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "No books found" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        [Route("Image")]
        [HttpPost]
        public IActionResult Image(IFormFile file, int id)
        {
            try
            {
                var result = this.bookManager.Image(file, id);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Image Upload Successful", Data = result });
                }
                return this.BadRequest(new { Status = false, Message = "Image Upload Un-Successful" });
            }
            catch (Exception e)
            {
                return this.NotFound(new { Status = false, Message = e.Message });
            }
        }
        
    }
}