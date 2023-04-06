using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BOilerplate.Repository
{
    public abstract class RepositoryBase
    {
        private readonly string _connectinSrtring;
        public RepositoryBase()
        {
            _connectinSrtring = "server=DESKTOP-EERLAR5\\SQLEXPRESS;database=database1;Integrated Security=SSPI;";

        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectinSrtring);
        }
    }

}
