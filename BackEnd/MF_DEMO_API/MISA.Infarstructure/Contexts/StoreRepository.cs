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
        /*public IEnumerable<Store> GetFilter(Object filter)
        {
            //var stores = _dbConnection.Query<Store>($"Proc_FilterStore",filter, commandType: CommandType.StoredProcedure);
            var stores = _dbConnection.Query<Store>($"SELECT * FROM Store s WHERE s.StoreCode LIKE ('%',@StoreCode,'%') AND s.StoreName LIKE CONCAT('%',@StoreName,'%') AND s.Address LIKE CONCAT('%',@Address,'%') AND s.PhoneNumber LIKE CONCAT('%',@PhoneNumber,'%') AND s.Status LIKE CONCAT('%',@Status,'%')");
            return stores;
        }*/
    }
}
