using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    [Serializable]
    public class ConfigRADT
    {
      
        public int HI { get; set; } = 0;
        public int AddorUpdate { get; set; } = 0;
        public string ProvinceCode { get; set; } = "084";
        public string NationCode { get; set; } = "079";
        public int Person { get; set; } = 0;
        public int Patient { get; set; } = 0;
        public int NextOfKins { get; set; } = 0;
        public int PatientAdmission { get; set; } = 0;             

    }
    
}
