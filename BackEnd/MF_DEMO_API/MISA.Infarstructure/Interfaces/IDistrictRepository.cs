using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.DataLayer.Interfaces
{
    public interface IDistrictRepository: IDbContext<District>
    {
        public IEnumerable<District> GetByProvinceId(string ProvinceId);
    }
}
