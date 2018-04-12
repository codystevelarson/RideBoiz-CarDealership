using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Attributes
{
    public class PriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is decimal)
            {
                decimal check = (decimal)value;

                if(check >= 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
