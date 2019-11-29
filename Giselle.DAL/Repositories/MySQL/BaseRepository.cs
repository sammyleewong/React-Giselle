using Giselle.DAL.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giselle.DAL.Repositories.MySQL
{
    public class BaseRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public BaseRepository(IOptions<DatabaseConfig> options)
        {
            _databaseConfig = options.Value;
        }

        public MySqlConnection CreateConnection()
        {
            return new MySqlConnection(_databaseConfig.ConnectionString);
        }
    }
}
