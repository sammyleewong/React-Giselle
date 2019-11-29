using System;
using System.Collections.Generic;

namespace Giselle.DAL.Models
{
    public partial class Club
    {
        public Club()
        {
            Team = new HashSet<Team>();
        }

        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public string ClubAddress { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Team> Team { get; set; }
    }
}
