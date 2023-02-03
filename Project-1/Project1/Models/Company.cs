namespace Models
{
    public class Company
    {
        public Company()
        {

        }

        public int user_id { get; set; }
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

        public string company()
        {
            return $@"{user_id},{Company_name}, {Company_type}, {Experience}, {Company_Description}";
        }
    }
}