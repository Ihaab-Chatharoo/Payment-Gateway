using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payment_Gateway.Models
{
    public class Information_table
{
        public Guid Id { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid Card Number")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Please enter a valid Card Number")]
        public string Card { get; set; }

        [Required]
        [Display(Name = "Expiry Date")]
        public DateTime Expiry { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid CVV")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Minimum 3 numbers required")]
        [Display(Name = "CVV")]
        public string Cvv { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Currency { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Amount { get; set; }

    }
}
