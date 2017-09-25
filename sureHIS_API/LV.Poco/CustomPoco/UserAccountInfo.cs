using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LV.Poco.CustomPoco
{
[Serializable]
public partial class UserAccountInfo
    {
[NotMapped]
        public string UserGroupID { get; set; }
           [NotMapped]
        public string UserGroupName { get; set; }
           [NotMapped]
        public bool FGroup { get; set; }
           [NotMapped]
        public bool CheckUser { get; set; }
    }
}