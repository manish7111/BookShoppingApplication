using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreModelLayer
{
    public class CustomerDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AddressId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string CityTown { get; set; }
        [Required]
        public string LandMark { get; set; }
        [Required]
        public string AddressType { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
