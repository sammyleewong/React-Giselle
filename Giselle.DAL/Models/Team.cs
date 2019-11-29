using System;
using System.Collections.Generic;

namespace Giselle.DAL.Models
{
    public partial class Team
    {
        public Team()
        {
            User = new HashSet<User>();
        }

        public int TeamId { get; set; }
        public int? ClubId { get; set; }
        public int? LeaugeId { get; set; }
        public int? MoveId { get; set; }
        public string TeamName { get; set; }
        public string HeadCoach { get; set; }
        public string HeadPhysio { get; set; }

        public virtual Club Club { get; set; }
        public virtual Leauge Leauge { get; set; }
        public virtual Moves Move { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
