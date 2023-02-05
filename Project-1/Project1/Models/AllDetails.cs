using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AllDetails
    {
        public AllDetails() { }
        public int user_id { get; set; }
        public string PASSWORD { get; set; }

        public string Email
        {
            get;
            set;
        }

        public string Full_name
        {
            get;
            set;
        }
        public int Age
        {
            get; set;
        }
        public string Gender
        {
            get;
            set;
        }
        public string Mobile_number
        {
            get;
            set;
        }
        public string Website
        {
            get;
            set;
        }
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

        public string Company_name
        {
            get;
            set;
        }

        public string Company_type
        {
            get;
            set;
        }

        public string Experience
        {
            get;
            set;
        }

        public string Company_Description
        {
            get;
            set;
        }

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
        public string AllTrainerDetails()
        {
            return $@"Email:{Email}\n,Fullname: {Full_name}\n,Age: {Age}\n,Gender: {Gender}\n,Mobile: {Mobile_number}\n,Web: {Website}\n,Skillname: {Skill_name}\n,SkillType: {Skill_Type}\n,SkillLevel: {Skill_Level}\n,Companyname: {Company_name}\n,CompanyType: {Company_type}\n,Experience: {Experience}\n,Company_desc: {Company_Description}\n,HighestGraduation: {Highest_Graduation}\n,Institute: {Institute}\n,Dept: {Department}\n,Startyear: {Start_year}\n,Endyear: {End_year}\n";
        }
    }
}
