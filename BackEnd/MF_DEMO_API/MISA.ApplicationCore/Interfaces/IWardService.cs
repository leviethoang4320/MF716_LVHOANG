using System;
using System.Collections.Generic;
using System.Text;
using MISA.Common.Models;

namespace MISA.Service.Interfaces
{
    public interface IWardService: IBaseService<Ward>
    {
        public IEnumerable<Ward> GetByDistrictId(string DistrictId);
    }
}
