using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Attributes
{
    public class YearAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is int)
            {
                int check = (int)value;

                if(check < DateTime.Now.Year + 1 && check > 1999)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
