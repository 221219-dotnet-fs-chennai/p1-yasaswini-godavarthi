using Serilog;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;


namespace TrainersData
{
    public class SqlRepo : IData
    {
        private readonly string connectionString;

        public SqlRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Details Add(Details details)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            string query = @"insert into Trainer_Detailes(Email, PASSWORD, Full_name, Age, Gender, Mobile_number, Website) values (@Email,@PASSWORD, @Full_name, @Age, @Gender, @Mobile_number, @Website)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Password", details.PASSWORD);
            command.Parameters.AddWithValue("@Email", details.Email);
            command.Parameters.AddWithValue("@Full_name", details.Full_name);
            command.Parameters.AddWithValue("@Age", Convert.ToInt32(details.Age));
            command.Parameters.AddWithValue("@gender", details.Gender);
            command.Parameters.AddWithValue("@Mobile_number", details.Mobile_number);
            command.Parameters.AddWithValue("@Website", details.Website);
            command.ExecuteNonQuery();


            string query1 = @"insert into Skills(Skill_name, Skill_Type, Skill_Level) values (@Skill_Name, @Skill_Type, @Skill_Level)";
            SqlCommand command1 = new SqlCommand(query1, connection);

            command1.Parameters.AddWithValue("@Skill_name", details.Skill_name);
            command1.Parameters.AddWithValue("@Skill_Type", details.Skill_Type);
            command1.Parameters.AddWithValue("@Skill_Level", details.Skill_Level);

            command1.ExecuteNonQuery();

            string query2 = @"insert into Company( Company_name, Company_type, Experience, Company_Description) values(@Company_name, @Company_type, @Experience, @Company_Description)";
            SqlCommand command2 = new SqlCommand(query2, connection);

            
            if (string.IsNullOrEmpty(details.Company_name))
            {
                command2.Parameters.AddWithValue("@Company_name", "Null");
            }
            else
            {
                command2.Parameters.AddWithValue("@Company_name", details.Company_name);
            }
            if (string.IsNullOrEmpty(details.Company_type))
            {
                command2.Parameters.AddWithValue("@Company_type", "Null");
            }
            else
            {
                command2.Parameters.AddWithValue("@Company_type", details.Company_type);
            }
            if (string.IsNullOrEmpty(details.Experience))
            {
                command2.Parameters.AddWithValue("@Experience", "Null");
            }
            else
            {
                command2.Parameters.AddWithValue("@Experience", details.Experience);
            }

            if (string.IsNullOrEmpty(details.Company_Description))
            {
                command2.Parameters.AddWithValue("@Company_Description", "Null");
            }
            else
            {
                command2.Parameters.AddWithValue("@Company_Description", details.Company_Description);
            }

            command2.ExecuteNonQuery();

            string query3 = @"insert into Education_Details( Highest_Graduation, Institute, Department, Start_year , End_year) values ( @Highest_Graduation, @Institute, @Department, @Start_year, @End_year)";
            SqlCommand command3 = new SqlCommand(query3, connection);

            //command3.Parameters.AddWithValue("@Edu_id", details.Edu_id);
            if (string.IsNullOrEmpty(details.Highest_Graduation))
            {
                command3.Parameters.AddWithValue("@Highest_Graduation", "Null");
            }
            else
            {
                command3.Parameters.AddWithValue("@Highest_Graduation", details.Highest_Graduation);
            }
            if (string.IsNullOrEmpty(details.Institute))
            {
                command3.Parameters.AddWithValue("@Institute", "Null");
            }
            else
            {
                command3.Parameters.AddWithValue("@Institute", details.Institute);
            }
            if (string.IsNullOrEmpty(details.Department))
            {
                command3.Parameters.AddWithValue("@Department", "Null");
            }
            else
            {
                command3.Parameters.AddWithValue("@Department", details.Department);
            }

            if (string.IsNullOrEmpty(details.Start_year))
            {
                command3.Parameters.AddWithValue("@Start_year", "Null");
            }
            else
            {
                command3.Parameters.AddWithValue("@Start_year", details.Start_year);
            }

            if (string.IsNullOrEmpty(details.End_year))
            {
                command3.Parameters.AddWithValue("@End_year", "Null");
            }
            else
            {
                command3.Parameters.AddWithValue("@End_year", details.End_year);
            }

            command3.ExecuteNonQuery();

            Console.WriteLine("row(s) added successfully");
            Console.ReadLine();

            return details;
        }

        
        public Details GetAllTrainer(string email)
        {
            Details detail = new Details();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            //List<Details> details = new List<Details>();

            try
            {

                string query = $@"Select * from Trainer_Detailes where Email = '{email}' ";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    detail.user_id = reader.GetInt32(0);
                    detail.Email = reader.GetString(2);
                    detail.Full_name = reader.GetString(1);
                    detail.Age = reader.GetInt32(3);
                    detail.Gender = reader.GetString(4);
                    detail.Mobile_number = reader.GetString(5);
                    detail.Website = reader.GetString(6);
                    detail.PASSWORD = reader.GetString(7);
                }
                reader.Close();

                
                string query1 = $"select user_id From Trainer_Detailes where Email = '{email}';";
                SqlCommand command2 = new SqlCommand(query1, con);
                int user_id = (int)command2.ExecuteScalar();

                string query2 = $@"Select * from Skills where user_id = {user_id} ";
                SqlCommand command3 = new SqlCommand(query2, con);
                SqlDataReader reader2 = command3.ExecuteReader();

                while (reader2.Read())
                {
                    detail.user_id = reader2.GetInt32(0);
                    detail.Skill_name = reader2.GetString(1);
                    detail.Skill_Type = reader2.GetString(2);
                    detail.Skill_Level = reader2.GetString(3);
                    
                }
                reader2.Close();

                string query3 = $@"Select * from Company where user_id = {user_id} ";
                SqlCommand command4 = new SqlCommand(query3, con);
                SqlDataReader reader3 = command4.ExecuteReader();

                while (reader3.Read())
                {
                    detail.user_id = reader3.GetInt32(0);
                    detail.Company_name = reader3.GetString(1);
                    detail.Company_type = reader3.GetString(2);
                    detail.Experience = reader3.GetString(3);
                    detail.Company_Description = reader3.GetString(4);
                }
                reader3.Close();

                string query4 = $@"Select * from Education_Details where user_id = {user_id} ";
                SqlCommand command5 = new SqlCommand(query4, con);
                SqlDataReader reader4 = command5.ExecuteReader();

                while (reader4.Read())
                {
                    detail.user_id = reader4.GetInt32(0);
                    detail.Highest_Graduation = reader4.GetString(1);
                    detail.Institute = reader4.GetString(2);
                    detail.Department = reader4.GetString(3);
                    detail.Start_year = reader4.GetString(4);
                    detail.End_year = reader4.GetString(5);
                }
                reader4.Close();
            }
            catch (SqlException ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
            }
            return detail;
        }

        public List<Details> GetAllTrainersDisconnected()
        {
            List<Details> details = new List<Details>();

            SqlConnection con = new SqlConnection(connectionString);

            string query5= @"Select Trainer_Detailes.user_id, Trainer_Detailes.Full_name, Trainer_Detailes.Email, Trainer_Detailes.Age, Trainer_Detailes.Gender, 
                Trainer_Detailes.Mobile_number, Trainer_Detailes.Website, Education_Details.Highest_Graduation, Education_Details.Institute, 
                Education_Details.Department, Education_Details.Start_year, Education_Details.End_year, Skills.Skill_name, Skills.Skill_Type,Skills.Skill_Level,
                Company.Company_name, Company.Company_type, Company.Experience, Company.Company_Description From Trainer_Detailes
                join Education_Details on Trainer_Detailes.user_id = Education_Details.user_id
                join Skills on Education_Details.user_id = Skills.user_id
                join Company on Skills.user_id = Company.user_id;";

            SqlDataAdapter adapter = new SqlDataAdapter(query5, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dtTrainer = ds.Tables[0];

            foreach (DataRow row in dtTrainer.Rows)
            {
                try
                {
                    details.Add(new Details()
                    {
                        user_id = (int)row["user_id"],
                        Email = (string)row["Email"],
                        Full_name = (string)row["Full_name"],
                        Age = (int)row["Age"],
                        Gender = (string)row["Gender"],
                        Mobile_number = (string)row["Mobile_number"],
                        Website = (string)row["Website"],
                        Highest_Graduation = (string)row["Highest_Graduation"],
                        Institute = (string)row["Institute"],
                        Department = (string)row["Department"],
                        Start_year = (string)row["Start_year"],
                        End_year = (string)row["End_year"],
                        Skill_name = (string)row["Skill_name"],
                        Skill_Type = (string)row["Skill_Type"],
                        Skill_Level = (string)row["Skill_Level"],
                        Company_name = (string)row["Company_name"],
                        Company_type = (string)row["Company_type"],
                        Experience = (string)row["Experience"],
                        Company_Description = (string)row["Company_Description"]
                    }) ; ;
                }
                catch(Exception e)
                {
                    System.Console.WriteLine(e);
                }
            }
            
            return details;
        }
        public bool login(string Email)
        {
            //_Emailid = Email;
            string query7 = $"select Email from Trainer_Detailes where Email='{Email}';";
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand command1 = new SqlCommand(query7, con);

            SqlDataReader reader = command1.ExecuteReader();

            if (reader.Read())
            {
                reader.Close();
                Console.Write("Enter you password: ");
                string password = System.Console.ReadLine();
                string query8 = $"select Email from Trainer_Detailes where Password='{password}';";
                SqlCommand command2 = new SqlCommand(query8, con);
                using SqlDataReader read1 = command2.ExecuteReader();
                if (read1.Read())
                {
                    Console.WriteLine("Login Success");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong Password");
                    read1.Close();
                    return false;
                }
            }
            else
            {
                Console.WriteLine("No data found");
                Console.ReadLine();
                return false;
            }
        }

        public void UpdateTrainer(string tableName, string columnName, string newValue, int user_id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            try
            {
                if (tableName == "Trainer_Detailes")
                {
                    if (columnName == "Age")
                    {
                        int newvalue = Convert.ToInt32(newValue);
                        string query = $"UPDATE {tableName} SET {columnName} = '{newvalue}' WHERE user_id = '{user_id}'";
                        SqlCommand command1 = new SqlCommand(query, con);
                        Log.Information($"{user_id} is this");
                        command1.ExecuteNonQuery();
                        Console.WriteLine("Data updated");
                    }
                    else
                    {
                        string query = $"UPDATE {tableName} SET {columnName} = '{newValue}' WHERE user_id = '{user_id}'";
                        SqlCommand command1 = new SqlCommand(query, con);
                        command1.ExecuteNonQuery();
                        Console.WriteLine("Data updated");
                    }
                }
                else
                {
                    string query = $"UPDATE {tableName} SEt {columnName} = '{newValue}' WHERE user_id = '{user_id}'";
                    SqlCommand command1 = new SqlCommand(query, con);
                    command1.ExecuteNonQuery();
                    Console.WriteLine("Data updated");
                }
                Console.WriteLine("*****Data updated Successfully*******");
                Console.ReadLine();
            }
            catch (Exception e){
                Console.WriteLine(e);
            }

        }
        public void DeleteTrainer(string col,string table, int user_id)
        {
            using SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            try
            {

                if (col == "Age")
                {
                    string query = $"UPDATE {table} set {col} = 0 where user_id = '{user_id}';";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string query = $"UPDATE {table} set {col} = 'Null' where user_id = '{user_id}';";
                    SqlCommand cmd = new SqlCommand(query, connect);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("________Data deleted successfully_________");
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void droptrainer(int userID)
        {
            using SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            try
            {
                string query1 = $"Delete from Education_Details where user_id = {userID};";
                string query2 = $"Delete from Company where user_id = {userID};";
                string query3 = $"Delete from Skills where user_id = {userID};";
                string query4 = $"Delete from Trainer_Detailes where user_id = {userID};";
                SqlCommand cmd1 = new SqlCommand(query1, connect);
                SqlCommand cmd2 = new SqlCommand(query2, connect);
                SqlCommand cmd3 = new SqlCommand(query3, connect);
                SqlCommand cmd4 = new SqlCommand(query4, connect);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                Console.WriteLine("------Deleted trainer Successfully----------");
                Console.WriteLine("Please Hit Enter To continue");
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        public Details SearchByEmail()
        {
            Console.WriteLine("Please Enter an Email To Continue");
            string email = Console.ReadLine();
            Details detail = new Details();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            List<Details> details = new List<Details>();
            string query = $@"SELECT td.Email, td.Full_name ,td.Age,Gender,td.Mobile_number,td.Website,s.Skill_name,s.Skill_Type,s.Skill_Level,
                              ed.Highest_Graduation,ed.Department,c.Company_name,c.Experience From Trainer_Detailes td join Skills s
                              on td.user_id = s.user_id JOIN Education_Details ed on ed.user_id = td.user_id join Company c 
                              on c.user_id = td.user_id where td.Email = '{email}';";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                detail.Email = reader.GetString(0);
                detail.Full_name = reader.GetString(1);
                detail.Age = reader.GetInt32(2);
                detail.Gender = reader.GetString(3);
                detail.Mobile_number = reader.GetString(4);
                detail.Website = reader.GetString(5);
                detail.Skill_name = reader.GetString(6);
                detail.Skill_Type = reader.GetString(7);
                detail.Skill_Level = reader.GetString(8);
                detail.Highest_Graduation = reader.GetString(9);
                detail.Department = reader.GetString(10);
                detail.Company_name = reader.GetString(11);
                detail.Experience = reader.GetString(12);

            }
            Console.Clear();
            Console.WriteLine(detail.Email.ToString());
            Console.WriteLine(detail.Full_name.ToString());
            Console.WriteLine( detail.Age);
            Console.WriteLine(detail.Gender.ToString());
            Console.WriteLine(detail.Mobile_number.ToString());
            Console.WriteLine(detail.Website.ToString());
            Console.WriteLine(detail.Skill_name.ToString());
            Console.WriteLine(detail.Skill_name.ToString());
            Console.WriteLine(detail.Skill_Level.ToString());
            Console.WriteLine(detail.Highest_Graduation.ToString());
            Console.WriteLine(detail.Department.ToString());
            Console.WriteLine(detail.Company_name.ToString());
            Console.WriteLine(detail.Experience.ToString());
            Console.ReadLine();
            reader.Close();
            return detail;
        }

    }
}

