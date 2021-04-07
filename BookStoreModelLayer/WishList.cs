using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer
{
    public class WishList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int WishListId { get; set; }
        [Required]
        [ForeignKey("Books")]
        public int BookId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
