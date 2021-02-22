using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class District { 
        public District()
        {
            DistrictId = Guid.NewGuid();
        }

        public Guid DistrictId { get; set; }

        public string DistrictId_
        {
            get
            {
                return DistrictId.ToString();
            }
        }
        public string DistrictName { get; set; }
        public Guid ProvinceId { get; set; }

        public string ProvinceId_
        {
            get
            {
                return ProvinceId.ToString();
            }
        }
    }
}
