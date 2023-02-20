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

        public bool Login(string email,string password)
        {
            return _data.Login(email, password);
        }

        public Details DeleteTrainer(string email,string password)
        {
            var s = _data.Login(email, password);
            if (s == true)
            {
                var t = _data.DeleteTrainer(email);
                if (t != null)
                {
                    return Mapper.TrainerMap(t);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception("Email Not Found! Try Again....");
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
        public FluentApi.TrainerData GetTrainerById(int id)
        {
            var search = _data.GetAllDetails().Where(r => r.user_id == id).FirstOrDefault();
            return search;
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
        

        public FluentApi.TrainerData SearchByEmail(string email)
        {
            var Ema = _data.GetAllDetails().Where(r => r.Email==email).FirstOrDefault();
            return Ema;
        }

        public Details UpdateTrainer(string email,string password, Details trainer)
        {
            var s = _data.Login(email, password);
            if (s == true)
            {
                var train = (from rst in _data.GetAllTrainers()
                             where rst.Email == email
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
            else
            {
                throw new Exception("Login Failed,Please Try Again.......");
            }
        }

        public Skills UpdateSkill(string email,string password, Skills skill)
        {
            var s = _data.Login(email, password);
            if (s == true)
            {
                var dummy = (from data in _data.GetAllTrainers()
                            where data.Email == email
                            select data).FirstOrDefault();
                int id = dummy.UserId;

                var train = (from rst in _data.GetAllSkills()
                             where rst.UserId == id
                             select rst).FirstOrDefault();
                if (train != null)
                {
                    train.UserId = id;
                    train.SkillName = skill.Skill_name;
                    train.SkillLevel = skill.Skill_Level;
                    train.SkillType = skill.Skill_Type;

                    train = _data.UpdateSkill(train);
                }

                return Mapper.SkillsMap(train);
            }
            else
            {
                throw new Exception("Login Failed! Please Try Again.....");
            }
        }

        public Models.Company UpdateCompany(string email, string password, Models.Company company)
        {
            var s = _data.Login(email, password);
            if (s == true)
            {
                var dummy = (from data in _data.GetAllTrainers()
                             where data.Email == email
                             select data).FirstOrDefault();
                int id = dummy.UserId;

                var train = (from rst in _data.GetAllCompanies()
                             where rst.UserId == id
                             select rst).FirstOrDefault();
                if (train != null)
                {
                    train.UserId = id;
                    train.CompanyName = company.Company_name;
                    train.CompanyType = company.Company_type;
                    train.Experience = company.Experience;
                    train.CompanyDescription = company.Company_Description;

                    train = _data.UpdateCompany(train);
                }

                return Mapper.CompanyMap(train);
            }
            else
            {
                throw new Exception("Login Failed! Please Try Again.....");
            }
        }

        public Models.EducationDetails UpdateEducation(string email, string password, Models.EducationDetails educationDetails)
        {
            var s = _data.Login(email, password);
            if (s == true)
            {
                var dummy = (from data in _data.GetAllTrainers()
                             where data.Email == email
                             select data).FirstOrDefault();
                int id = dummy.UserId;

                var train = (from rst in _data.GetEducationDetails()
                             where rst.UserId == id
                             select rst).FirstOrDefault();
                if (train != null)
                {
                    train.UserId = id;
                    train.HighestGraduation = educationDetails.Highest_Graduation;
                    train.Institute = educationDetails.Institute;
                    train.Department = educationDetails.Department;
                    train.StartYear = educationDetails.Start_year;
                    train.EndYear = educationDetails.End_year;

                    train = _data.UpdateEducation(train);
                }

                return Mapper.EducationMap(train);
            }
            else
            {
                throw new Exception("Login Failed! Please Try Again.....");
            }
        }

    }
}