using Giselle.DAL.Models;
using System.Collections.Generic;

namespace Giselle.BAL.Services.Abstract
{
    public interface IUserService
    {
        IEnumerable<User> Get(int? UserID);
    }
}