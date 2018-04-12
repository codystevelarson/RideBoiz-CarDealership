using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required]
        [StringLength(17, MinimumLength =17, ErrorMessage = "VIN must be 17 characters")]
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
        [StringLength(250, ErrorMessage = "Last name cannot exceed 250 characters")]
        public string Message { get; set; }
        public bool Contacted { get; set; } //For v2 when you can lookup contact messages and check off if you replied to them

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
