using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer
{
    public class OrderSummary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }
        [Required]
        [DefaultValue(null)]
        public string OrderNumber { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
