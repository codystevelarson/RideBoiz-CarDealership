using GuildCars.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class SaleItem
    {
        public int SaleId { get; set; }
        public string VIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string StateId { get; set; }
        public int Zipcode { get; set; }
        public decimal PurchasePrice { get; set; }
        public PurchaseType PurchaseType { get; set; }
        public string UserName { get; set; }
    }
}
