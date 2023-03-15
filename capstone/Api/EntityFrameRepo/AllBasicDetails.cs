using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameRepo
{
    public class AllBasicDetails
    {
        public AllBasicDetails()
        {

        }
        public Guid Id { get; set; }
        public DateTime Date_Time { get; set; }
        public string Patient_Id { get; set; }
        public string Nurse_Id { get; set; }
        public string Bp { get; set; }
        public int Heart_Rate { get; set; }
        public string SpO2 { get; set; }
        public string Health_Id { get; set; }
        public string Allergy { get; set; }

    }
}
