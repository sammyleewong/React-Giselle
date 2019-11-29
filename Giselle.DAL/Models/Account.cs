using System;
using System.Collections.Generic;

namespace Giselle.DAL.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool? LockoutEnabled { get; set; }
        public bool AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public virtual User User { get; set; }
    }
}
