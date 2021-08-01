using CustomerOrderViewer2._0.Models;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CustomerOrderViewer2._0.Repositories
{
    class CustomerOrderCommand
    {
        private string _connectionString;

        public CustomerOrderCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Delete(int customerOrderId, string userId)
        {
            var upsertStatement = "customerorderdetail_delete";

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                connection.Execute(upsertStatement, new { @CustomerOrderId= customerOrderId, @UserId= userId },commandType: CommandType.StoredProcedure);
            }
        }

        public IList<CustomerOrderDetailModel> GetList()
        {
            List<CustomerOrderDetailModel> customerOrderDetails = new List<CustomerOrderDetailModel>();

            var sql = "CustomerOrderDetail_GetList";

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                customerOrderDetails = connection.Query<CustomerOrderDetailModel>(sql).ToList();
            }

            return customerOrderDetails;
        }
    }
}
