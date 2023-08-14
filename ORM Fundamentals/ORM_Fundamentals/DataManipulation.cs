using ORM_Fundamentals.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace ORM_Fundamentals
{
    public class DataManipulation
    {
        private ApplicationDbContext dbContext;

        public DataManipulation(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public void BulkDeleteOrdersUsingStoredProc(int? year = null, int? month = null, OrderStatus? status = null, int? productId = null)
        {
            using (var connection = dbContext.Database.GetDbConnection())
            {
                connection.Open();
                using (var deleteOrders = connection.CreateCommand())
                {
                    deleteOrders.CommandText = "spBulkDeleteOrders";
                    deleteOrders.CommandType = CommandType.StoredProcedure;

                    // Add parameters using the CreateParameter method
                    AddParameter(deleteOrders, "@Year", year);
                    AddParameter(deleteOrders, "@Month", month);
                    AddParameter(deleteOrders, "@Status", status != null ? (int)status : (object)DBNull.Value);
                    AddParameter(deleteOrders, "@ProductId", productId);

                    deleteOrders.ExecuteNonQuery();
                }
            }
        }

        private void AddParameter(DbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
        }
    }
}
