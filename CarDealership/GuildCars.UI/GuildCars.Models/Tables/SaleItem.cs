using GuildCars.Models.Attributes;
using GuildCars.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class SaleItem
    {
        public int SaleId { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be 17 characters")]
        public string VIN { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters")]
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        [StringLength(30, ErrorMessage = "Phone number cannot exceed 30 characters")]
        public string Phone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string Street1 { get; set; }

        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string Street2 { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "State Id cannot exceed 2 characters")]
        public string StateId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string City { get; set; }

        [Required]
        [Zipcode(ErrorMessage = "Zipcode must be 5 digits")]
        public int Zipcode { get; set; }

        [Required]
        [Price(ErrorMessage = "Price must be a positive number")]
        public decimal PurchasePrice { get; set; }

        [Required]
        public PurchaseType PurchaseType { get; set; }
        public string UserId { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(Email))
            {
                results.Add(new ValidationResult("Must provide either phone or email"));
            }

            return results;
        }
    }
}
