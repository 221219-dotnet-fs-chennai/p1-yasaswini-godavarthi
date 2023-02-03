using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Skills
    {
        public Skills()
        {

        }
        public int user_id { get; set; }
        public string Skill_name
        {
            get;
            set;
        }

        public string Skill_Type
        {
            get;
            set;
        }

        public string Skill_Level
        {
            get;
            set;
        }

        public string skills()
        {
            return $@"{user_id},{Skill_name}, {Skill_Type}, {Skill_Level}";
        }
    }
}
