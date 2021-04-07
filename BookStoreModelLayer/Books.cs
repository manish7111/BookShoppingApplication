using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer
{
    public class Books
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Summary { get; set; }
        public string BookImage { get; set; }
        [Required]
        public int BookCount { get; set; }
    }
}
