using CustomerOrderViewer2._0.Models;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace CustomerOrderViewer2._0.Repositories
{
    class ItemCommand
    {
        private string _connectionString;

        public ItemCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<ItemModel> GetList()
        {
            List<ItemModel> items = new List<ItemModel>();

            var sql = "Item_GetList";

            using (OracleConnection connection=new OracleConnection(_connectionString))
            {
                items = connection.Query<ItemModel>(sql).ToList();
            }

                return items;
        }
    }
}
