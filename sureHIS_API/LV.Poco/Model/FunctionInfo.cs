using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    public class FunctionInfo
    {
        public FunctionList Function { get; set; }
        public FunctionList[] FunctionList { get; set; }
    }
    public class ChildFunction
    {
        public string DefaultName { get; set; }
        public string URL { get; set; }
        public string FunctionID { get; set; }
        public string SmallIcon { get; set; }
        public int IndexChildren { get; set; }
        public bool ShowHide { get; set; }
        public string ResultAPI { get; set; }

        public string StoreName { get; set; }
    }
    [Serializable]
    public class RootFunction
    {
        public string DefaultName { get; set; }
        public List<ChildFunction> children { get; set; }
        public string FunctionID { get; set; }
        public int IndexMaster { get; set; }
        public bool ShowHide { get; set; }
    }
}
