using System;
using System.Collections.Generic;

namespace Giselle.DAL.Models
{
    public partial class MoveType
    {
        public MoveType()
        {
            Moves = new HashSet<Moves>();
        }

        public int MoveTypeId { get; set; }
        public string MoveTypeDesc { get; set; }

        public virtual ICollection<Moves> Moves { get; set; }
    }
}
