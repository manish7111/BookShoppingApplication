using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer
{
    public class BookStore
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }
        public string BookImage { get; set; }
        public int BookCount { get; set; }
        public bool IsWishlist { get; set; }
        public bool IsCart { get; set; }
    }
}
