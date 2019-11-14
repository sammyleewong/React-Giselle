using System;
using System.Collections.Generic;

namespace Giselle.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Account = new HashSet<Account>();
        }

        public int UserId { get; set; }
        public int? UserTypeId { get; set; }
        public int? ClubId { get; set; }
        public int? TeamId { get; set; }
        public int? PlayerProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public string WorkAddress { get; set; }

        public virtual Team Team { get; set; }
        public virtual PlayerProfile UserNavigation { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<Account> Account { get; set; }
    }
}
