using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    public struct RunCostingInfo
    {
        public string PeriodID { get; set; }
        public string ZObjectID { get; set; }
        public string WorkshopID { get; set; }
        public string StageID { get; set; }
        public bool CheckProTrans { get; set; }
        public bool CheckSelfPricePre { get; set; }

    }
}
