using System.Data;

namespace ADO_NET_Solution.Interfaces
{
    public interface IDatabaseConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
