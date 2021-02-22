using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Service;
using MISA.Service.Interfaces;

namespace MISA.DEMO.API.Controllers
{
    public class StoresController : BaseEntityController<Store>
    {
        
        IStoreService _baseService;
        public StoresController(IStoreService baseService) : base(baseService)
        {
            _baseService = baseService;
        }
        /*[HttpGet("filter/{code}&{name}/{address}/{phone}/{status}")]
        public IActionResult Get(string code, string name, string address, string phone, string status)
        {
            
            var stores = _baseService.GetFilter(code,name,address,phone,status);
            return Ok(stores);
        }*/
    
}
}
