using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using GuildCars.Models.Tables;

namespace GuildCars.BLL.Managers
{
    public class MakeManager
    {
        private IMakeRepository Repo { get; set; }

        public MakeManager(IMakeRepository makeRepository)
        {
            Repo = makeRepository;
        }


        public MakeResponse GetMake(int id)
        {
            var response = new MakeResponse();

            if (id == 0)
            {
                response.Success = false;
                response.Message = "Must provide a valid make id";
                return response;
            }

            response.Make = Repo.GetMake(id);

            if (response.Make == null)
            {
                response.Success = false;
                response.Message = $"No make found with id {id}";
                return response;
            }

            response.Success = true;
            return response;
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

        public MakeResponse Add(Make make)
        {
            var response = new MakeResponse();

            if(string.IsNullOrEmpty(make.MakeName))
            {
                response.Success = false;
                response.Message = "Make must have a name";
                return response;
            }

            if(string.IsNullOrEmpty(make.UserId))
            {
                response.Success = false;
                response.Message = "No User ID assigned to make";
                return response;
            }

            if(string.IsNullOrEmpty(make.UserName))
            {
                response.Success = false;
                response.Message = "No Username assigned to make";
                return response;
            }

            response.Make = Repo.Add(make);

            if(response.Make.MakeId == 0)
            {
                response.Success = false;
                response.Message = "Failed to add Make";
                return response;
            }
            response.Success = true;
            return response;
        }

        public MakeResponse GetMakeByModelId(int id)
        {
            var response = new MakeResponse();

            response.Make = Repo.GetMakeByModelId(id);

            if (response.Make == null)
            {
                response.Success = false;
                response.Message = $"Failed to load Make with model id {id}";
                return response;
            }
            response.Success = true;
            return response;
        }

    }
}
