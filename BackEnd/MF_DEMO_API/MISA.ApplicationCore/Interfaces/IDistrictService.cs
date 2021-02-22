using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.Service.Interfaces
{
   public interface IDistrictService: IBaseService<District>
    {
        public IEnumerable<District> GetByProvinceId(string ProvinceId);
    }
}
