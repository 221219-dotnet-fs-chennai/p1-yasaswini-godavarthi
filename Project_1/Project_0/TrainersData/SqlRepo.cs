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

        public void DeleteTrainer(string eMail)
        {
            throw new NotImplementedException();
        }

        public List<Details> GetAllTrainerDetails(int i)
        {
            List<Details> details = new List<Details>();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            if (i == 1)
            {
                Console.WriteLine("please enter your Email to continue:");
                string email = Console.ReadLine();
                string q1 = $@"Select * from Trainer_Detailes where Email = '{email}'";
                SqlDataAdapter adapter = new SqlDataAdapter(q1, con);
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
                            Website = (string)row["Website"]
                        });
                        Console.WriteLine(row);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("please enter your user_id to continue:");
                string userID = Console.ReadLine();
                if (i == 2)
                {
                    string q2 = $@"Select * from Education_Details where user_id = '{userID}'";
                    SqlDataAdapter adapt = new SqlDataAdapter(q2, con);
                    DataSet ds1 = new DataSet();
                    adapt.Fill(ds1);

                    DataTable dtTrainer1 = ds1.Tables[0];

                    foreach (DataRow row in dtTrainer1.Rows)
                    {
                        try
                        {
                            details.Add(new Details()
                            {
                                user_id = (int)row["user_id"],
                                Highest_Graduation = (string)row["Highest_Graduation"],
                                Institute = (string)row["Institute"],
                                Department = (string)row["Department"],
                                Start_year = (string)row["Start_year"],
                                End_year = (string)row["End_year"]
                            });
                            Console.WriteLine(row);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                if (i == 3)
                {
                    string q1 = $@"Select * from Skills where user_id = '{userID}'";
                    SqlDataAdapter adapter = new SqlDataAdapter(q1, con);
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
                                Skill_name = (string)row["Skill_name"],
                                Skill_Type = (string)row["Skill_Type"],
                                Skill_Level = (string)row["Skill_Level"]
                            });
                            Console.WriteLine(row);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                if (i == 4)
                {
                    string q1 = $@"Select * from Company where user_id = '{userID}'";
                    SqlDataAdapter adapter = new SqlDataAdapter(q1, con);
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
                                Company_name = (string)row["Company_name"],
                                Company_type = (string)row["Company_type"],
                                Experience = (string)row["Experience"],
                                Company_Description = (string)row["Company_Description"]
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            return details;
        }
        public Details GetAllTrainer(string email)
        {
            Details detail = new Details();

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            List<Details> details = new List<Details>();

            try
            {

                string query4 = $@"Select Trainer_Detailes.user_id, Trainer_Detailes.Full_name, Trainer_Detailes.Email, Trainer_Detailes.Age, Trainer_Detailes.Gender, 
                Trainer_Detailes.Mobile_number, Trainer_Detailes.Website, Education_Details.Highest_Graduation, Education_Details.Institute, 
                Education_Details.Department, Education_Details.Start_year, Education_Details.End_year, Skills.Skill_name, Skills.Skill_Type,Skills.Skill_Level,
                Company.Company_name, Company.Company_type, Company.Experience, Company.Company_Description From Trainer_Detailes
                join Education_Details on Trainer_Detailes.user_id = Education_Details.user_id
                join Skills on Education_Details.user_id = Skills.user_id
                join Company on Skills.user_id = Company.user_id where Trainer_Detailes.Email = '{email}';";

                SqlCommand command = new SqlCommand(query4, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    details.Add(new Details()
                    {
                        user_id = reader.GetInt32("user_id"),
                        Email = reader.GetString("Email"),
                        Full_name = reader.GetString("Full_name"),
                        Age = reader.GetInt32("Age"),
                        Gender = reader.GetString("Gender"),
                        Mobile_number = reader.GetString("Mobile_number"),
                        Website = reader.GetString("Website"),
                        Highest_Graduation = reader.GetString("Highest_Graduation"),
                        Institute = reader.GetString("Institute"),
                        Department = reader.GetString("Department"),
                        Start_year = reader.GetString("Start_year"),
                        End_year = reader.GetString("End_year"),
                        Skill_name = reader.GetString("Skill_name"),
                        Skill_Type = reader.GetString("Skill_Type"),
                        Skill_Level = reader.GetString("Skill_Level"),
                        Company_name = reader.GetString("Company_name"),
                        Company_type = reader.GetString("Company_type"),
                        Experience = reader.GetString("Experience"),
                        Company_Description= reader.GetString("Company_Description")
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
                Console.WriteLine("Data updated Successfully");
                Console.ReadLine();
            }
            catch (Exception e){
                Console.WriteLine(e);
            }

        }
    }
}