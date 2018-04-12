using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.TestRepos
{
    public class InteriorRepositoryTEST : IInteriorRepository
    {
        private static List<Interior> _interiors;

        public InteriorRepositoryTEST()
        {
            _interiors = new List<Interior>
            {
                new Interior {InteriorId = 1, InteriorName = "Cloth"},
                new Interior {InteriorId = 2, InteriorName = "Leather"},
                new Interior {InteriorId = 3, InteriorName = "Suede"},
                new Interior {InteriorId = 4, InteriorName = "Velvet"},
                new Interior {InteriorId = 5, InteriorName = "Walnut"},
                new Interior {InteriorId = 6, InteriorName = "Creme"},
                new Interior {InteriorId = 7, InteriorName = "Mink"},
                new Interior {InteriorId = 8, InteriorName = "Alligator"},
                new Interior {InteriorId = 9, InteriorName = "Gucci"},
                new Interior {InteriorId = 10, InteriorName = "Custom"}
            };
        }

        public Interior Get(int id)
        {
            return _interiors.SingleOrDefault(i => i.InteriorId == id);
        }

        public List<Interior> GetAll()
        {
            return _interiors;
        }
    }
}
