using System.Text.RegularExpressions;

namespace Models
{
    public class Details
    {
        public Details()
        {

        }

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

        /*public string detail()
        {
            return $@"{user_id},{Email}, {Full_name}, {Age}, {Gender}, {Mobile_number}, {Website},{PASSWORD}";
        }*/

        /*public string TrainerDetails()
        {
            return $@"{Email}, {Full_name}, {Age}, {Gender}, {Mobile_number}, {Website}";
        }*/
    }
}