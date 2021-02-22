using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Province
    {
        public Province()
        {
            ProvinceId = Guid.NewGuid();
        }

        public Guid ProvinceId { get; set; }

        public string ProvinceId_
        {
            get
            {
                return ProvinceId.ToString();
            }
        }
        public string ProvinceName { get; set; }
    }
}
