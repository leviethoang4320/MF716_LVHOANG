using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Ward
    {
        public Ward()
        {
            WardId = Guid.NewGuid();
        }

        public Guid WardId { get; set; }

        public string WardId_
        {
            get
            {
                return WardId.ToString();
            }
        }
        public string WardName { get; set; }
        public Guid DistrictId { get; set; }

        public string DistrictId_
        {
            get
            {
                return DistrictId.ToString();
            }
        }
    }
}
