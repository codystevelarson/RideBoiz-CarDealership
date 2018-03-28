using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL.Managers
{
    public class MakeManager
    {
        private IMakeRepository Repo { get; set; }

        public MakeManager(IMakeRepository makeRepository)
        {
            Repo = makeRepository;
        }

        public MakeResponse GetAll()
        {
            var response = new MakeResponse();

            response.Makes = Repo.GetMakes();
            if (response.Makes == null)
            {
                response.Success = false;
                response.Message = "Cound not find any makes in database";
                return response;
            }
            response.Success = true;
            return response;
        }

        

    }
}
