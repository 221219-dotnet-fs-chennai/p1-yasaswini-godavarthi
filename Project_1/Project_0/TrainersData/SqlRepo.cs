using Serilog;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;


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


            string query = @"insert into Trainer_Detailes(Email, Password, Full_name, Age, Gender, Mobile_number, Website) values (@Email,@Password, @Full_name, @Age, @Gender, @Mobile_number, @Website)";
            SqlCommand command = new SqlCommand(query, connection);

            //command.Parameters.AddWithValue("@user_id", details.user_id);
            command.Parameters.AddWithValue("@Password", details.Password);
            command.Parameters.AddWithValue("@Email", details.Email);
            command.Parameters.AddWithValue("@Full_name", details.Full_name);
            command.Parameters.AddWithValue("@Age", Convert.ToInt32(details.Age));
            command.Parameters.AddWithValue("@gender", details.Gender);
            command.Parameters.AddWithValue("@Mobile_number", details.Mobile_number);
            command.Parameters.AddWithValue("@Website", details.Website);
            command.ExecuteNonQuery();


            string query1 = @"insert into Skills(Skill_name, Skill_Type, Skill_Level) values (@Skill_Name, @Skill_Type, @Skill_Level)";
            SqlCommand command1 = new SqlCommand(query1, connection);

           // command1.Parameters.AddWithValue("@Skill_id", details.Skill_id);
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

            string query3 = @"insert into Education_Details(Highest_Graduation, Institute, Department, Start_year , End_year) values ( @Highest_Graduation, @Institute, @Department, @Start_year, @End_year)";
            SqlCommand command3 = new SqlCommand(query3, connection);

            //command3.Parameters.AddWithValue("@Edu_id", details.Edu_id);
            command3.Parameters.AddWithValue("@Highest_Graduation", details.Highest_Graduation);
            command3.Parameters.AddWithValue("@Institute", details.Institute);
            command3.Parameters.AddWithValue("@Department", details.Department);
            command3.Parameters.AddWithValue("@Start_year", details.Start_year);
            command3.Parameters.AddWithValue("@End_year", details.End_year);

            command3.ExecuteNonQuery();

            Console.WriteLine("row(s) added successfully");
            Console.ReadLine();

            return details;
        }

        public void DeleteTrainer(string eMail)
        {
            throw new NotImplementedException();
        }

        public Details GetAllTrainer(string email)
        {
            Details detail = new Details();

            //string[] emailarr = email.Split("@");
            //detail.user_id = emailarr[0];

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            List<Details> details = new List<Details>();

            try
            {

                string query4 = @"Select Trainer_Detailes.user_id, Trainer_Detailes.Full_name, Trainer_Detailes.Email, Trainer_Detailes.Age, Trainer_Detailes.Gender, 
                Trainer_Detailes.Mobile_number, Trainer_Detailes.Website,Education_Details.Edu_id, Education_Details.Highest_Graduation, Education_Details.Institute, 
                Education_Details.Department, Education_Details.Start_year, Education_Details.End_year,Skills.Skill_id, Skills.Skill_name, Skills.Skill_Type,Skills.Skill_Level,
                Company.Id,Company.Company_name, Company.Company_type, Company.Experience, Company.Company_Description From Trainer_Detailes
                join Education_Details on Trainer_Detailes.user_id = Education_Details.Edu_id
                join Skills on Education_Details.Edu_id = Skills.Skill_id
                join Company on Skills.Skill_id = Company.Id where Trainer_Detailes.Email = email;";

                SqlCommand command = new SqlCommand(query4, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    details.Add(new Details()
                    {
                        user_id = reader.GetInt32(0),
                        Email = reader.GetString(2),
                        Full_name = reader.GetString(1),
                        Age = reader.GetInt32(3),
                        Gender = reader.GetString(4),
                        Mobile_number = reader.GetString(5),
                        Website = reader.GetString(6),
                        Edu_id = reader.GetInt32(7),
                        Highest_Graduation = reader.GetString(8),
                        Institute = reader.GetString(9),
                        Department = reader.GetString(10),
                        Start_year = reader.GetString(11),
                        End_year = reader.GetString(12),
                        Skill_id = reader.GetInt32(13),
                        Skill_name = reader.GetString(14),
                        Skill_Type = reader.GetString(15),
                        Skill_Level = reader.GetString(16),
                        Id = reader.GetInt32(17),
                        Company_name = reader.GetString(18),
                        Company_type = reader.GetString(19),
                        Experience = reader.GetString(20),
                        Company_Description= reader.GetString(21)
                    });
                }
                reader.Close();
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
                Trainer_Detailes.Mobile_number, Trainer_Detailes.Website,Education_Details.Edu_id, Education_Details.Highest_Graduation, Education_Details.Institute, 
                Education_Details.Department, Education_Details.Start_year, Education_Details.End_year,Skills.Skill_id, Skills.Skill_name, Skills.Skill_Type,Skills.Skill_Level,
                Company.Id,Company.Company_name, Company.Company_type, Company.Experience, Company.Company_Description From Trainer_Detailes
                join Education_Details on Trainer_Detailes.user_id = Education_Details.Edu_id
                join Skills on Education_Details.Edu_id = Skills.Skill_id
                join Company on Skills.Skill_id = Company.Id;";

            SqlDataAdapter adapter = new SqlDataAdapter(query5, con);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dtTrainer = ds.Tables[0];

            foreach (DataRow row in dtTrainer.Rows)
            {
                details.Add(new Details()
                {
                    user_id = (int) row[0],
                    Email = (string)row[2],
                    Full_name = (string)row[1],
                    Age = (int)row[3],
                    Gender = (string)row[4],
                    Mobile_number = (string)row[5],
                    Website = (string)row[6],
                    Edu_id = (int)row[7],
                    Highest_Graduation = (string)row[8],
                    Institute = (string)row[9],
                    Department = (string)row[10],
                    Start_year = (string)row[11],
                    End_year = (string)row[12],
                    Skill_id = (int)row[13],
                    Skill_name = (string)row[14],
                    Skill_Type = (string)row[15],
                    Skill_Level = (string)row[16],
                    Id = (int)row[17],
                    Company_name = (string)row[18],
                    Company_type = (string)row[19],
                    Experience = (string)row[20],
                    Company_Description = (string)row[21]
                });
            }

            return details;
        }
        public bool login(string Email)
        {
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
            if (tableName is "Trainer_Detailes") {
                if (columnName is "Age")
                {
                    int newvalue = Convert.ToInt32(newValue);
                    string query = $"update '{tableName}' set '{columnName}' = '{newvalue}' where user_id = '{user_id}'";
                    SqlCommand command1 = new SqlCommand(query, con);
                    Log.Information($"{user_id} is this");
                    command1.ExecuteNonQuery();
                    Console.WriteLine("Data updated");
                }
                else
                {
                    string query = $"update '{tableName}' set '{columnName}' = '{newValue}' where user_id = '{user_id}'";
                    SqlCommand command1 = new SqlCommand(query, con);
                    command1.ExecuteNonQuery();
                    Console.WriteLine("Data updated");
                }
            }
            if (tableName is "Skills")
            {
                string query = $"update '{tableName}' set '{columnName}' = '{newValue}' where user_id = details.Skill_id";
                SqlCommand command1 = new SqlCommand(query, con);
                command1.ExecuteNonQuery();
                Console.WriteLine("Data updated");
            }
            if (tableName is "Company")
            {
                string query = $"update '{tableName}' set '{columnName}' = '{newValue}' where user_id = details.Id'";
                SqlCommand command1 = new SqlCommand(query, con);
                command1.ExecuteNonQuery();
                Console.WriteLine("Data updated");
            }
            if (tableName is "Education_Details")
            {
                string query = $"update '{tableName}' set '{columnName}' = '{newValue}' where user_id = details.Edu_id";
                SqlCommand command1 = new SqlCommand(query, con);
                command1.ExecuteNonQuery();
                Console.WriteLine("Data updated");
            }
            Console.WriteLine("Data updated Successfully");

        }
    }
}