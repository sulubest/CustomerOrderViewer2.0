using CustomerOrderViewer2._0.Models;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerOrderViewer2._0.Repositories
{
    class CustomerCommand
    {
        private string _connectionString;

        public CustomerCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<CustomerModel> GetList()
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            var sql = "Customer_GetList";

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                customers = connection.Query<CustomerModel>(sql).ToList();
            }

            return customers;
        }
    }
}
