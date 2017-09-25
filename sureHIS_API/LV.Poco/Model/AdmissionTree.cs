using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    public class AdmissionTreeDetail
    {
        public long AdmID { get; set; }
        public string Text { get; set; }
    }

    public class AdmissionTree
    {
       public string Text { get; set; }
       public List<AdmissionTreeDetail> TreeDetail { get; set; }
    }
}
