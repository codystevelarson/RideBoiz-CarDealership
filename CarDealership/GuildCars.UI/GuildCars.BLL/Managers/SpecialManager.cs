using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using GuildCars.Models.Tables;
using System.Linq;

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


        public SpecialResponse Get(int id)
        {
            var response = new SpecialResponse();

            response.Special = Repo.GetSpecial(id);

            if(response.Special == null)
            {
                response.Success = false;
                response.Message = $"Cound not find special with id {id}";
                return response;
            }
            response.Success = true;
            return response;
        }


        public SpecialResponse Add(Special special)
        {
            var response = new SpecialResponse();

            if (string.IsNullOrEmpty(special.SpecialName))
            {
                response.Success = false;
                response.Message = "Special must have a name";
                return response;
            }

            if(string.IsNullOrEmpty(special.Description))
            {
                response.Success = false;
                response.Message = "Special must have a description";
                return response;
            }

            if(string.IsNullOrEmpty(special.ImageFileName))
            {
                response.Success = false;
                response.Message = "Special Must have an image";
                return response;
            }


            response.Special = Repo.Add(special);

            if (response.Special.SpecialId == 0)
            {
                response.Success = false;
                response.Message = "Failed to add Special";
                return response;

            }
            response.Success = true;

            return response;
        }


        public SpecialResponse Delete(int id)
        {
            var response = new SpecialResponse();

            Repo.Delete(id);

            if(Repo.GetSpecials().Any(s => s.SpecialId == id))
            {
                response.Success = false;
                response.Message = "Failed to delete special from database";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
