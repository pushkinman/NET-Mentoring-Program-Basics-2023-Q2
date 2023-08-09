using ADO_NET_Solution.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET_Solution.Testing
{
    public class ConnectionFactory : IDatabaseConnectionProvider
    {
        public IDbConnection GetConnection()
        {
            return new SqlConnection("Data Source=(localdb)\\\\MSSQLLocalDB;Initial Catalog=ADO_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        }
    }

}
