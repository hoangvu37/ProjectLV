using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LV.Poco
{
    [Serializable]
    public class BaseEntity
    {
        [NotMapped]
        public string FieldHaveAvaliable { get; set; }
        [NotMapped]
        public bool IsNotEdit { get; set; }
        [NotMapped]
        public int sysSTT { get; set; }
        [NotMapped]
        public bool _IsAdd { get; set; }
        [NotMapped]
        public string _KeyOld { get; set; }
    }

}
