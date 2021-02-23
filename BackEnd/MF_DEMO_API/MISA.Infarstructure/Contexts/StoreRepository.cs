using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer.Contexts
{
    public class StoreRepository: DbContext<Store>, IStoreRepository
    {
        public IEnumerable<Store> GetByFilter(string code, string name, string address, string phone, string status)
        {
            //var stores = _dbConnection.Query<Store>($"Proc_FilterStore",filter, commandType: CommandType.StoredProcedure);
            var sql = $"SELECT * FROM Store s WHERE s.StoreCode LIKE CONCAT('%','{code}','%') AND s.StoreName LIKE CONCAT('%','{name}','%') AND s.Address LIKE CONCAT('%','{address}','%') AND s.PhoneNumber LIKE CONCAT('%','{phone}','%') AND s.Status LIKE CONCAT('%','{status}','%')";
            var stores = _dbConnection.Query<Store>(sql);
            return stores;
        }
    }
}
