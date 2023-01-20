using System.Text.RegularExpressions;

namespace TrainersData
{
    public class Details
    {
        public Details()
        {

        }

        public int user_id { get; set; }
        public string Password { get; set; }
        public int Skill_id { get; set; }
        public int Id { get; set; }
        public int Edu_id { get; set; }

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

        public string TrainerDetails()
        {
            return $@"{Email}, {Full_name}, {Age}, {Gender}, {Mobile_number}, {Website}, {Skill_name}, {Skill_Type}, {Skill_Level}, {Company_name}, {Company_type}, {Experience}, {Company_Description}, {Highest_Graduation}, {Institute}, {Department}, {Start_year}, {End_year}";
        }
    }
}