using Giselle.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giselle.DAL.Repositories.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Get(int? UserID);
    }
}
