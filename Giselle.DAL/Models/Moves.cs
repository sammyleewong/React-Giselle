using System;
using System.Collections.Generic;

namespace Giselle.DAL.Models
{
    public partial class Moves
    {
        public Moves()
        {
            Team = new HashSet<Team>();
        }

        public int MoveId { get; set; }
        public int? MoveTypeId { get; set; }
        public string MoveName { get; set; }
        public string MoveDesc { get; set; }
        public int? TeamId { get; set; }

        public virtual MoveType MoveType { get; set; }
        public virtual ICollection<Team> Team { get; set; }
    }
}
