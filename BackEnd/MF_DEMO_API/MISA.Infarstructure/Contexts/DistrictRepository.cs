using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using MISA.Common.Models;
using MISA.DataLayer.Interfaces;

namespace MISA.DataLayer.Contexts
{
    public class DistrictRepository : DbContext<District>, IDistrictRepository
    {
        #region Method
        public IEnumerable<District> GetByProvinceId(string ProvinceId)
        {
            var sql = $"SELECT * FROM District WHERE ProvinceId = '{ProvinceId}' ";
            return _dbConnection.Query<District>(sql);
        }

        #endregion
    }
}
