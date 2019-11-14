using System;
using System.Collections.Generic;

namespace Giselle.DAL.Models

{
    public partial class PlayerProfile
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int? Caps { get; set; }
        public string PositionOne { get; set; }
        public string PositionTwo { get; set; }
        public string PositionThree { get; set; }

        public virtual User User { get; set; }
    }
}
