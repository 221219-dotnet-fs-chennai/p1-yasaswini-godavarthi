using Models;
using FluentApi;
using FluentApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic
{
    public class Logic : ILog
    {
        IData _data;
        public Logic(IData data) 
        {
            _data = data;
        }

        public Details Add(Details trainer)
        {
            return Mapper.TrainerMap(_data.Add(Mapper.TrainerMap(trainer)));
        }
        public EducationDetails AddEdu(EducationDetails trainer)
        {
            return Mapper.EducationMap(_data.AddEdu(Mapper.EducationMap(trainer)));
        }

        public Skills Addskill(Skills s) 
        {
            return Mapper.SkillsMap(_data.Addskill(Mapper.SkillsMap(s)));
        }

        public Models.Company Addcompany(Models.Company company)
        {
            return Mapper.CompanyMap(_data.Addcompany(Mapper.CompanyMap(company)));
        }


        public Models.EducationDetails edetails(EducationDetails trainerid,int Hg)
        {
            return _data.edetails(trainerid,Hg);
        }

        public bool Login(string email,string password)
        {
            return _data.Login(email, password);
        }

        /*public AllDetails AddAll(AllDetails a)
        {

            return (_add.AddTrainer(a));
        }*/

        public Details DeleteTrainer(string name)
        {
            var t = _data.DeleteTrainer(name);
            if(t!= null)
            {
                return Mapper.TrainerMap(t);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<FluentApi.TrainerData> GetAllDetails()
        {
            return _data.GetAllDetails();
        }

        public IEnumerable<Details> GetAllTrainers()
        {
            return Mapper.TrainerMap(_data.GetAllTrainers());
        }

        public IEnumerable<Skills> GetAllSkills()
        {
            return Mapper.SkillsMap(_data.GetAllSkills());
        }

        public IEnumerable<EducationDetails> GetEducationDetails()
        {
            return Mapper.EducationMap(_data.GetEducationDetails());
        }

        public IEnumerable<Models.Company> GetAllCompanies()
        {
            return Mapper.CompanyMap(_data.GetAllCompanies());
        }
        public Details GetTrainerById(int id)
        {
            var search = _data.GetAllTrainers().Where(r => r.UserId == id).FirstOrDefault();
            return Mapper.TrainerMap(search);
        }


        public IEnumerable<FluentApi.TrainerData> GetBySkillName(string skillName)
        {
            var search = _data.GetAllDetails().Where(r => r.Skill_name == skillName);
            return search;
        }

        public IEnumerable<FluentApi.TrainerData> GetByExperience(string exp)
        {
            var search = _data.GetAllDetails().Where(r => r.Experience == exp);
            return search;
        }

        public IEnumerable<FluentApi.TrainerData> GetByHg(string hg)
        {
            var search = _data.GetAllDetails().Where(r=>r.Highest_Graduation == hg);
            return search;
        }
        

        public IEnumerable<Details> SearchByEmail(string email)
        {
            var Ema = _data.GetAllTrainers().Where(r => r.Email==email);
            return Mapper.TrainerMap(Ema);
        }

        public Details UpdateTrainer(string name, Details trainer)
        {
            var train = (from rst in _data.GetAllTrainers()
                              where rst.FullName == name &&
                              rst.UserId == trainer.user_id
                              select rst).FirstOrDefault();
            if (train != null)
            {
                train.Email = trainer.Email;
                train.FullName = trainer.Full_name;
                train.Gender = trainer.Gender;
                train.Age = trainer.Age;
                train.MobileNumber = trainer.Mobile_number;
                train.Website = trainer.Website;
                train.Password = trainer.PASSWORD;


                train = _data.UpdateTrainer(train);
            }

            return Mapper.TrainerMap(train);
        }

        public Skills UpdateSkill(int id, Skills skill)
        {
            var train = (from rst in _data.GetAllSkills()
                         where rst.UserId == id
                         select rst).FirstOrDefault();
            if (train != null)
            {
                train.SkillName = skill.Skill_name;
                train.SkillLevel = skill.Skill_Level;
                train.SkillType = skill.Skill_Type;

                train = _data.UpdateSkill(train);
            }

            return Mapper.SkillsMap(train);
        }

        public IEnumerable<TrainerData> UpdateDetailes(string email)
        {
            throw new NotImplementedException();
        }


        /*public FluentApi.Entities.Company UTrainer(int id, FluentApi.Entities.Company c)
        {
            var train = (from rst in _data.GetAllDetails()
                         where rst.user_id == id &&
                         rst.user_id == c.UserId
                         select rst).FirstOrDefault();
            if (train != null)
            {
                train.Company_Description = c.CompanyDescription;
                train.Company_type=c.CompanyType;
                train.Company_name = c.CompanyName;
                train.Experience = c.Experience;


                train = _data.UTrainer(train);
            }

            return Mapper.CompanyMap(train);
        }*/
    }
}