using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer
{
    public class BookCartResponse
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }
        public string BookImage { get; set; }
        public int BookCount { get; set; }
        public int SelectedBookCount { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
    }
}
