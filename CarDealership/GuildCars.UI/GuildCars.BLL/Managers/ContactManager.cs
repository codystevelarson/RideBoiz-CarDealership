using GuildCars.BLL.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using GuildCars.Models.Tables;
using System.Linq;

namespace GuildCars.BLL.Managers
{
    public class ContactManager
    {
        private IContactRepository Repo { get; set; }

        public ContactManager(IContactRepository contactRepository)
        {
            Repo = contactRepository;
        }


        public ContactResponse Add(Contact contact)
        {
            var response = new ContactResponse();

            //Validate
            if(string.IsNullOrEmpty(contact.Email) && string.IsNullOrEmpty(contact.Phone))
            {
                response.Success = false;
                response.Message = "Email or Phone must be filled out";
                return response;
            }

            if(string.IsNullOrEmpty(contact.FirstName))
            {
                response.Success = false;
                response.Message = "Must provide a first name";
                return response;

            }

            if (string.IsNullOrEmpty(contact.LastName))
            {
                response.Success = false;
                response.Message = "Must provide a last name";
                return response;

            }

            if (contact.VIN.Count() != 17)
            {
                response.Success = false;
                response.Message = "VIN must be 17 characters";
                return response;
            }

            if (string.IsNullOrEmpty(contact.Message))
            {
                response.Success = false;
                response.Message = "Must provide a message";
                return response;

            }

            var vehicleManager = VehicleManagerFactory.Create();
            var vehicleResponse = vehicleManager.GetVehicle(contact.VIN);
            
            if(!vehicleResponse.Success)
            {
                response.Success = false;
                response.Message = $"VIN: {contact.VIN} does not exist in the inventory";
                return response;
            }

            response.Contact = Repo.Add(contact);

            if(response.Contact.ContactId == 0)
            {
                response.Success = false;
                response.Message = "Failed to add contact to database";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
