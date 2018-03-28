using GuildCars.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicle
    {
        public string VIN { get; set; }
        public bool New { get; set; }
        public int Year { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public string ColorName { get; set; }
        public string InteriorName { get; set; }
        public Transmission Transmission { get; set; }
        public int Mileage { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRP { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
        public bool Sold { get; set; }
        public string ImageFileName { get; set; }
    }
}
