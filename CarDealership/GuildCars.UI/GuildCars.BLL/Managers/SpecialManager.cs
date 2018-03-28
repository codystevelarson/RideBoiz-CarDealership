using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL.Managers
{
    public class SpecialManager 
    {
        private ISpecialRepository Repo { get; set; }

        public SpecialManager(ISpecialRepository specialRepository)
        {
            Repo = specialRepository;
        }

        public SpecialResponse GetAll()
        {
            var response = new SpecialResponse();

            response.Specials = Repo.GetSpecials();

            if(response.Specials == null)
            {
                response.Success = false;
                response.Message = "Cound not find any specials in database";
                return response;
            }
            response.Success = true;
            return response;
        }

    }
}
