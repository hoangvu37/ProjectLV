using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    class GridviewObject
    {
    }

    public class SortGridSetting
    {
        public string UserGrouId { get; set; }
        public string GridViewName { get; set; }
        public string Sort { get; set; }
        public string Fileds { get; set; }
    }
    public class ColumnGridSetting
    {
        public string UserGroupId { get; set; }
        public string GridViewName { get; set; }
        public string Column { get; set; }
        public short Width { get; set; }
    }
    public class GridSetup
    {
       public string enityName { get; set; }
        public ColumnGridSetting column {get;set;}
       public GridViewSetup[] gridSetup { get; set; }
    }
}
