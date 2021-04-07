using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CartId { get; set; }
        [Required]
        [ForeignKey("Books")]
        public int BookId { get; set; }
        [Required]
        public int SelectedBookCount { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
