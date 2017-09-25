using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LV.Core.DAL.EntityFramework
{
    [Serializable]
    [DataContract(IsReference = true)]
    [KnownType(typeof(DatabaseInfo))]
    public class DatabaseInfo
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string DBName { get; set; }
        [DataMember]
        public string ProviderName { get; set; }
        [DataMember]
        public string LoginName { get; set; }
        [DataMember]
        public string DataSource { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Schema { get; set; }
    }
}
