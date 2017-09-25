using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    public class GroupInfo
    {
        public UserAccount Group { get; set; }
        public UserAccount[] AccountList { get; set; }
    }

    public class GroupInfoWithPopup
    {
        public string UserGroupId { get; set; }
        public string UserGroupName { get; set; }
        public string Description { get; set; }
    }
}
