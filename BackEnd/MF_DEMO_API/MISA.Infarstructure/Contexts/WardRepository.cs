using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer.Contexts
{
    public class WardRepository: DbContext<Ward>, IWardRepository
    {
        public IEnumerable<Ward> GetByDistrictId(string DistrictId)
        {
            var sql = $"SELECT * FROM Ward WHERE DistrictId = '{DistrictId}' ";
            return _dbConnection.Query<Ward>(sql);
        }
    }
}
