using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    public class TreeViewObject
    {
        public int dataindex { get; set; }
        public Application application { get; set; }        
        public List<TreeViewObject> items { get; set; }
    }
}
