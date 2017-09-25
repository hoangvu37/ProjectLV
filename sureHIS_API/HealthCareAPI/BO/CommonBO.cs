using HealthCareAPI.DTO;
using HealthCareAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCareAPI.BO
{
    public class CommonBO
    {
        private CommonService _commonService;

        public CommonBO(CommonService commonService)
        {
            _commonService = commonService;
        }

        public IList<CustomerDTO> getDataForTest()
        {
            // xu ly logic o day
            return _commonService.getDataForTest();
        }
    }
}