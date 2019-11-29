using Dapper;
using Giselle.DAL.Configuration;
using Giselle.DAL.Models;
using Giselle.DAL.Repositories.Abstract;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Giselle.DAL.Repositories.MySQL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IOptions<DatabaseConfig> options) : base(options)
        {
        }

        public IEnumerable<User> Get(int? UserID)
        {
            using (MySqlConnection connection = base.CreateConnection())
            {
                return connection.Query<User>(sql: "rspUserGet",
                                              param: new { in_userid = UserID },
                                              commandType: CommandType.StoredProcedure);
            }
        }
    }
}
