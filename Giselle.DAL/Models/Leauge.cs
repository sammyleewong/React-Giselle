using System;
using System.Collections.Generic;

namespace Giselle.DAL.Models
{
    public partial class Leauge
    {
        public Leauge()
        {
            Team = new HashSet<Team>();
        }

        public int LeaugeId { get; set; }
        public string LeaugeName { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Team> Team { get; set; }
    }
}
