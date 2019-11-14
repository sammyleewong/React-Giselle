using Giselle.DAL.Configuration;
using Giselle.DAL.Models;
using Giselle.DAL.Repositories.Abstract;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Giselle.DAL.Repositories.MSSQL
{
    public class UserRepository : BaseRepository//, IUserRepository
    {
        public UserRepository(IOptions<DatabaseConfig> options) : base(options)
        {
        }

        //public IEnumerable<User> Get(int? UserID)
        //{
        //    //using (SqlConnection connection = base.CreateConnection())
        //    //{
        //    //    return connection.Query<User>(sql: "rspUserGet",
        //    //                                  param: new { @userid = UserID },
        //    //                                  commandType: CommandType.StoredProcedure);
        //    //}
        //   return null;
        //}
    }
}
