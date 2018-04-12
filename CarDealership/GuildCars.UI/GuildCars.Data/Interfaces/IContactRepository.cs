using GuildCars.Models.Tables;

namespace GuildCars.Data.Interfaces
{
    public interface IContactRepository
    {
        Contact Add(Contact contact);
    }
}
