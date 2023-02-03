using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EducationDetails
    {
        public EducationDetails()
        {
                
        }

        public int user_id { get; set; }
        public string Highest_Graduation
        {
            get;
            set;
        }

        public string Institute
        {
            get;
            set;
        }
        public string Department
        {
            get;
            set;
        }
        public string Start_year
        {
            get;
            set;
        }

        public string End_year
        {
            get;
            set;
        }

        public string EducationDetail()
        {
            return $@"{user_id},{Highest_Graduation}, {Institute}, {Department}, {Start_year}, {End_year}";
        }
    }
}
