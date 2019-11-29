using System;
using System.Collections.Generic;

namespace Giselle.DAL.Models
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int UserTypeId { get; set; }
        public string UserDesc { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
