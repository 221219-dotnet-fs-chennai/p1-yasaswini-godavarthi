using Models;
using FluentApi;

namespace Business_Logic
{
    public class Logic : ILog
    {
        IData<FluentApi.Entities.TrainerDetaile> _data;
        public Logic(IData<FluentApi.Entities.TrainerDetaile> data) 
        {
            _data = data;
        }
        

        public IEnumerable<Details> GetAllTrainers()
        {
            return Mapper.Map(_data.GetAllTrainers());
        }
        public IEnumerable<Details> GetAllTrainersBySkillname(string Skill_name33)
        {
            return Mapper.Map(_data.GetAllTrainers().Where(r=>r.Skill.SkillName == Skill_name33));
        }
        

        public IEnumerable<Details> SearchByEmail(string email)
        {
            var s = _data.GetAllTrainers().Where((r) => r.Email == email);
            return Mapper.Map(s);
        }

        public IEnumerable<Details> SearchByExperience(string Exp)
        {
            var E = _data.GetAllTrainers().Where((r) => r.Company.Experience == Exp);
            return Mapper.Map(E);
        }
    }
}