using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giselle.DAL.Models
{
    public class BaseModel
    {
        [JsonIgnore]
        public int CreateUserID { get; set; }
    }
}
