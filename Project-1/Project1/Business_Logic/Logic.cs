using Models;
using TrainersData;

namespace Business_Logic
{
    public class Logic : ILog
    {
        IData data;
        //string connectionString = File.ReadAllText("../../../connectionString.txt");
        public Logic(string connectionString)
        {
            data = new SqlRepo(connectionString);
        }

        public IEnumerable<Details> GetAllTrainersDisconnected()
        {
            return data.GetAllTrainersDisconnected();
        }
        public IEnumerable<Details> GetAllTrainersBySkillname(string Skill_name33)
        {
            return data.GetAllTrainersDisconnected().Where(r=>r.Skill_name == Skill_name33);
        }
        

        public Details SearchByEmail()
        {
            return data.SearchByEmail();
        }

        public IEnumerable<Details> SearchByExperience(string Exp)
        {
            return data.GetAllTrainersDisconnected().Where((r)=>r.Experience == Exp);
        }
    }
}