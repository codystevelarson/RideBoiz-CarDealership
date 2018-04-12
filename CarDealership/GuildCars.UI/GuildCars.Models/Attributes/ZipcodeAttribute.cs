using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Attributes
{
    public class ZipcodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value is int)
            {
                int check = (int)value;
                
                if(check > 9999 &&  check < 100000)
                {
                    return true;
                }
            }
            return false; 
        }
    }
}
