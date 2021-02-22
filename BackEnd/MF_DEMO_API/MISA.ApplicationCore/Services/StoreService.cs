using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service.Services
{
    public class StoreService: BaseService<Store>,IStoreService
    {
        IStoreRepository _dbContext;
        public StoreService(IStoreRepository dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        /*public IEnumerable<Store> GetFilter(object filter)
        {
            return _dbContext.GetFilter(filter);
        }*/
    }
}
