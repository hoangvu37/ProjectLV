using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    [Serializable]
    public class ServiceItem
    {
        public long MedSerID { get; set; }
        public string MedSerName { get; set; }
        public long HISerItemID { get; set; }
        public string HISerItemName { get; set; }
        public float? UnitPrice { get; set; }
        public float? HIUnitPrice { get; set; }
        public float? SurCharge { get; set; }
        public string UOMID { get; set; }
        public long EMSID { get; set; }
        public long HosDeptID { get; set; }
        public int CountServiceItem { get; set; }
        public long MedSerTypeID { get; set; }
        public int CurCode { get; set; }
        public int HIPaymentRate { get; set; }
        public long? HosFeeTransDtlID { get; set; }
        public long? TransID { get; set; }
        public long? HosFeeTransID { get; set; }

    }
}
