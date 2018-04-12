using System.Collections.Generic;

namespace GuildCars.UI.Models
{
    public class UserGroupVM
    {
        public List<UserVM> Admins { get; set; }
        public List<UserVM> Sales { get; set; }
        public List<UserVM> Disabled { get; set; }
    }
}