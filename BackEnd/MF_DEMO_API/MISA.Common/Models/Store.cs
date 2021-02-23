using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
   
        public class Store
        {
            public Store()
            {

                StoreId = Guid.NewGuid();
                Status = "Đang hoạt động";
            }
            public Guid StoreId { get; set; }
        

        [Required("Mã cửa hàng")]
            [CheckDuplicate("Mã cửa hàng")]
            [MaxLength("Mã cửa hàng", 20)]
            public string StoreCode { get; set; }

            [Required("Tên cửa hàng")]
            public string StoreName { get; set; }

            [Required("Địa chỉ")]
            public string Address { get; set; }

            [CheckDuplicate("Số điện thoại")]
            public string PhoneNumber { get; set; }
            public string Status { get; set; }
           

            
            public string TaxCode { get; set; }
            public string Street { get; set; }

            public String StoreId_
            {

                get
                {
                    return StoreId.ToString();
                }
            }
            public string WardId { get; set; }
            /*public String WardId_
            {
                get
                {
                return WardId.ToString();
                
                }
            }*/
        public string DistrictId { get; set; }
        /*public String DistrictId_
        {
            get
            {
                return DistrictId.ToString();
               
            }
        }*/
        public string ProvinceId { get; set; }
        /*public String ProvinceId_
        {
            get
            {
                return ProvinceId.ToString();
                
            }
        }*/


    }
    
}
