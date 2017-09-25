using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    [Serializable]
    public class UserPermissionModel
    {
        public string UserGroupID { get; set; }
        public TreeViewObject[] FunctionList { get; set; }
    }

    public class PermissionModel
    {
        public string FunctionId { get; set; }
        public string DefaultName { get; set; }
        public bool View { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Print { get; set; }
        public bool Import { get; set; }
        public bool Export { get; set; }
        public bool _isView { get; set; }
        public bool _isAdd { get; set; }
        public bool _isEdit { get; set; }
        public bool _isDelete { get; set; }
        public bool _isPrint { get; set; }
        public bool _isImport { get; set; }
        public bool _isExport { get; set; }
    }

    
}
