using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.Interfaces
{
    public interface IStoreRepository: IDbContext<Store>
    {
        public IEnumerable<Store> GetByFilter(string code, string name, string address, string phone, string status);
    }
}
