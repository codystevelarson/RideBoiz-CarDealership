using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.TestRepos
{
    public class MakeRepositoryTEST : IMakeRepository
    {
        private static List<Make> _makes;

        public MakeRepositoryTEST()
        {
            _makes = new List<Make>
            {
                new Make { MakeId = 1, MakeName = "Ford", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" },
                new Make { MakeId = 2, MakeName = "Chevy", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" },
                new Make { MakeId = 3, MakeName = "Dodge", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" },
                new Make { MakeId = 4, MakeName = "Saturn", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" },
                new Make { MakeId = 5, MakeName = "Kia", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" }
            };
        }


        public Make Add(Make make)
        {
            if (_makes.Any())
            {
                make.MakeId = _makes.Max(m => m.MakeId) + 1;
            }
            else
            {
                make.MakeId = 1;
            }
            _makes.Add(make);
            return make;
        }

        public Make GetMake(int makeId)
        {
            return _makes.SingleOrDefault(m => m.MakeId == makeId);
        }

        public Make GetMakeByModelId(int id)
        {
            //Created but implementation broke the correct ui functionallity
            throw new NotImplementedException();
        }

        public List<Make> GetMakes()
        {
            return _makes;
        }
    }
}
