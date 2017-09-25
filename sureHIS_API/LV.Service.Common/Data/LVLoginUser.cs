using LV.Core.DAL.EntityFramework;
using LV.Poco;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LV.Service.Common
{
    public class LVLoginUser : IPrincipal
    {

        #region Properties
        public UserAccount account { get; set; }      
        public string FirstName { get; set; }
        public string ProfilePhoto { get; set; }
        public string PersName { get; set; }
        public long Code { get; set; }
        public string UserCode { get; set; }    
        public string SessionID { get; set; }
        public string AccountID { get; set; }
        public string PersonID { get; set; }
        public string EmpID { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string ConfigByUser { get; set; }
        public DatabaseInfo DatabaseInfo { get; set; }

        [XmlIgnore]
        public Dictionary<string, List<string>> GroupBUByUser { get; set; }
        #endregion

        #region Method       

        #endregion

        public IIdentity Identity
        {
            get { return new Identity(this.account.AccountNameEmailAddress); }
        }

        public bool IsInRole(string role)
        {
            return true;
        }
    }
    public class Identity : IIdentity
    {
        private string _Name;
        public Identity(string name)
        {
            _Name = name;
        }
        public string AuthenticationType
        {
            get { return ""; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return _Name; }
        }
    }

}
