using Giselle.DAL.Configuration;
using Microsoft.Extensions.Options;
using Giselle.DAL.Repositories.MSSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Giselle.DAL.Repositories.MSSQL
{
   public  class BaseRepository
    {        
            private readonly DatabaseConfig _databaseConfig;

            public BaseRepository(IOptions<DatabaseConfig> options)
            {
                _databaseConfig = options.Value;
            }

            //public SqlConnection CreateConnection()
            //{
            //    return new SqlConnection(_databaseConfig.ConnectionString);
            //}
        
    }
}
