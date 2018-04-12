using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.TestRepos
{
    public class SpecialRepositoryTEST : ISpecialRepository
    {
        private static List<Special> _specials;

        public SpecialRepositoryTEST()
        {
            _specials = new List<Special>
            {
                new Special { SpecialId = 1, SpecialName = "Special1", Description = "1 - Special", ImageFileName = "special1.jpg" },
                new Special { SpecialId = 2, SpecialName = "Special2", Description = "2 - Special", ImageFileName = "special2.jpg" },
                new Special { SpecialId = 3, SpecialName = "Special3", Description = "3 - Special", ImageFileName = "special3.jpg" },
                new Special { SpecialId = 4, SpecialName = "Special4", Description = "4 - Special", ImageFileName = "special4.jpg" },
                new Special { SpecialId = 5, SpecialName = "Special5", Description = "5 - Special", ImageFileName = "special5.jpg" },
            };
        }

        public Special Add(Special special)
        {
            if (_specials.Any())
            {
                special.SpecialId = _specials.Max(s => s.SpecialId) + 1;
            }
            else
            {
                special.SpecialId = 1;
            }
            _specials.Add(special);
            return special;
        }

        public void Delete(int id)
        {
            Special special = _specials.SingleOrDefault(s => s.SpecialId == id);
           _specials.Remove(special);
        }

        public Special GetSpecial(int id)
        {
            return _specials.SingleOrDefault(s => s.SpecialId == id);
        }

        public List<Special> GetSpecials()
        {
            return _specials;
        }
    }
}
