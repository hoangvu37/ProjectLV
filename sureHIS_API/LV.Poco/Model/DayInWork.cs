using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    [Serializable]
    public class DayInWork
    {
        public long V_DayName { get; set; }
        public string VNObjectValue { get; set; }
        public Nullable<TimeSpan> StartTime { get; set; }
        public Nullable<TimeSpan> EndTime { get; set; }
        public bool IsDelete { get; set; }

    }
    [Serializable]
    public class WorkDayTime
    {
        public long V_DayName { get; set; }
        public string VNObjectValue { get; set; }
        public string TimeWork { get; set; }
        public Nullable<TimeSpan> StartTimeAM { get; set; }
        public Nullable<TimeSpan> EndTimeAM { get; set; }
        public Nullable<TimeSpan> StartTimePM { get; set; }
        public Nullable<TimeSpan> EndTimePM { get; set; }

    }
    [Serializable]
    public class HosSpecia
    {
        public long WDID { get; set; }
        public string DepName { get; set; }
        public string DepNameRemoveUnicode { get; set; }
    }
    [Serializable]
    public class Doctor
    {
        public long WDID { get; set; }
        public long EmpID { get; set; }
        public string PersName { get; set; }
        public string PersNameRemoveUnicode { get; set; }

        public string AcademicName { get; set; }

        public string ProfilePhoto { get; set; }

        public string PstnName { get; set; }
    }
    [Serializable]
    public class EmployeeLeaveTakenModel
    {
        public long EmpID { get; set; }
        public string PersName { get; set; }
        public string AcademicName { get; set; }
        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }
    [Serializable]
    public class EmployeeLeaveTakenMaster
    {
        public long WDID { get; set; }
        public string DepName { get; set; }

        public List<EmployeeLeaveTakenModel> doctorlist { get; set; }

    }
}
