using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV.Poco.Model
{
    public class RegistrationModel
    {
        public Patient Patient { get; set; }
        public Person Person { get; set; }
        public NextOfKins NextOfKins { get; set; }
        public PatientAdmission PatientAdmission { get; set; }
        public HealthInsurance HealthInsurance { get; set; }
        public MedicalEncounter MedicalEncounter { get; set; }
        public PatientMedRecord PatientMedRecord { get; set; }
        public PatientCommonMedRecord PatientCommonMedRecord { get; set; }
        public ConfigRADT ConfigRADT { get; set; }
        public Dictionary<object, object> PatientVitalSign { get; set; }
        public List<ServiceItem> ServiceItem { get; set; }

    }
}
