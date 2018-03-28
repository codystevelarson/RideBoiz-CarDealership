using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class UserGroupVM
    {
        public List<UserVM> Admins { get; set; }
        public List<UserVM> Sales { get; set; }
        public List<UserVM> Disabled { get; set; }
    }
}