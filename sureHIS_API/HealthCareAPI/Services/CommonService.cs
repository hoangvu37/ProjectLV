using HealthCareAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareAPI.Services
{
    public class CommonService
    {
        public IList<CustomerDTO> getDataForTest()
        {
            var list = new List<CustomerDTO>();
            list.Add(new CustomerDTO { Id = 1, Name = "Hiep" });

            return list;
        }
    }
}