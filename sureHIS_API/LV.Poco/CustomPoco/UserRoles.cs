using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco
{
    public class UserRoles
    {
        public string FunctionID { get; set; }

        public string ActionName { get; set; }

        public int View { get; set; }
        public int Add { get; set; }
        public int Edit { get; set; }
        public int Delete { get; set; }
        public int UserShare { get; set; }
    }
}
