using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    public class UserAccountInfo
    {
        public UserAccount UserAccount { get; set; }
        public UserAccount[] GroupAccount { get; set; }
    }

    public struct UserChangePassword
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
