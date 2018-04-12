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
    public class Vehicle
    {
        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be 17 characters")]
        public string VIN { get; set; }
        public bool New { get; set; }

        [Required]
        [Year(ErrorMessage ="Year must be between 1900 and 1 year from current year")]
        public int Year { get; set; }

        public CarModel Model { get; set; }

        [Required]
        public BodyStyle BodyStyle { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        public Interior Interior { get; set; }

        [Required]
        public Transmission Transmission { get; set; }

        [Required]
        public int Mileage { get; set; }
        
        //cannot be greater than MSRP
        [Required]
        [Price(ErrorMessage = "Must be a positive number")]
        public decimal SalePrice { get; set; }

        //cannot be less than sale price
        [Required]
        [Price(ErrorMessage = "Must be a positive number")]
        public decimal MSRP { get; set; }

        [Required]
        [StringLength(180, ErrorMessage = "Description cannot exceed 180 characters")]
        public string Description { get; set; }
        public bool Featured { get; set; }
        public bool Sold { get; set; }
        public string ImageFileName { get; set; }

        public Vehicle()
        {
            Model = new CarModel();
            Model.Make = new Make();
            Color = new Color();
            Interior = new Interior();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (SalePrice > MSRP)
            {
                results.Add(new ValidationResult("Sale Price cannot be greater than MSRP"));
            }

            return results;
        }
    }
}
