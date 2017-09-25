using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco
{
    public class Setting
    {
        public AccountSetting Account { get; set; }
        public UserAccountPolicy System { get; set; }
        public Dictionary<string, Dictionary<string,bool>> Permission { get; set; }
    }

    public class AccountSetting
    {
        public bool CantChangePwd { get; set; }
        public bool PwdNeverExpired { get; set; }
        public bool MustChangePwd { get; set; }
    }
    public class PermissionList
    {
        public string Function { get; set; }
        public bool Value { get; set; }
    }
}
