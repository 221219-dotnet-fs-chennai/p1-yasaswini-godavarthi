using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentApi.Entities;

namespace Business_Logic
{
    public class Mapper
    {
        public static Models.AllDetails Map(FluentApi.TrainerData d)
        {
            return new Models.AllDetails()
            {
                user_id = d.user_id,
                PASSWORD = Validations.IsValidPassword(d.PASSWORD),
                Email = Validations.IsValidEmailId(d.Email),
                Full_name = d.Full_name,
                Mobile_number = Validations.IsValidMobileNumber(d.Mobile_number),
                Age = Convert.ToInt32(d.Age),
                Gender = Validations.IsValidGender(d.Gender),
                Website = d.Website,
                Company_name = d.Company_name,
                Company_type = d.Company_type,
                Experience = d.Experience,
                Company_Description = d.Company_Description,
                Skill_name = d.Skill_name,
                Skill_Level = d.Skill_Level,
                Skill_Type = d.Skill_Type,
                Highest_Graduation = d.Highest_Graduation,
                Institute = d.Full_name,
                Start_year = d.Start_year,
                End_year = d.End_year,
                Department = d.Department
            };
        }


        public static FluentApi.TrainerData Map(Models.AllDetails a)
        {
            return new FluentApi.TrainerData()
            {
                user_id = a.user_id,
                PASSWORD = Validations.IsValidPassword(a.PASSWORD),
                Email = Validations.IsValidEmailId(a.Email),
                Full_name = a.Full_name,
                Mobile_number = Validations.IsValidMobileNumber(a.Mobile_number),
                Age = Convert.ToInt32(a.Age),
                Gender = Validations.IsValidGender(a.Gender),
                Website = Validations.IsValidWebsite(a.Website),
                Company_name = a.Company_name,
                Company_type = a.Company_type,
                Experience = a.Experience,
                Company_Description = a.Company_Description,
                Skill_name = a.Skill_name,
                Skill_Level = a.Skill_Level,
                Skill_Type = a.Skill_Type,
                Highest_Graduation = a.Highest_Graduation,
                Institute = a.Institute,
                Start_year = a.Start_year,
                End_year = a.End_year,
                Department = a.Department,

            };
        }


        public static Models.Details TrainerMap(FluentApi.Entities.TrainerDetaile o)
        {
            return new Models.Details()
            {
                user_id = o.UserId,
                PASSWORD = Validations.IsValidPassword(o.Password),
                Email = Validations.IsValidEmailId(o.Email),
                Full_name = o.FullName,
                Mobile_number = Validations.IsValidMobileNumber(o.MobileNumber),
                Age = Convert.ToInt32(o.Age),
                Gender = Validations.IsValidGender(o.Gender),
                Website = Validations.IsValidWebsite(o.Website), 
            };
        }

        public static FluentApi.Entities.TrainerDetaile TrainerMap(Models.Details o)
        {
            return new FluentApi.Entities.TrainerDetaile()
            {
                UserId = o.user_id,
                Password = Validations.IsValidPassword(o.PASSWORD),
                Email = Validations.IsValidEmailId(o.Email),
                FullName = o.Full_name,
                MobileNumber = Validations.IsValidMobileNumber(o.Mobile_number),
                Age = Convert.ToInt32(o.Age),
                Gender = Validations.IsValidGender(o.Gender),
                Website = Validations.IsValidWebsite(o.Website),
            };
        }

        public static Models.Company CompanyMap(FluentApi.Entities.Company o)
        {
            return new Models.Company()
            {
                user_id = o.UserId,
                Company_name = o.CompanyName,
                Company_type = o.CompanyType,
                Experience = o.Experience,
                Company_Description = o.CompanyDescription
            };
        }

        public static FluentApi.Entities.Company CompanyMap(Models.Company o)
        {
            return new FluentApi.Entities.Company()
            {
                UserId = o.user_id,
                CompanyName = o.Company_name,
                CompanyType = o.Company_type,
                Experience = o.Experience,
                CompanyDescription = o.Company_Description
            };
        }

        public static Models.Skills SkillsMap(FluentApi.Entities.Skill o)
        {
            return new Models.Skills()
            {
                user_id = o.UserId,
                Skill_name = o.SkillName,
                Skill_Level = o.SkillLevel,
                Skill_Type = o.SkillType
            };
        }

        public static FluentApi.Entities.Skill SkillsMap(Models.Skills o)
        {
            return new FluentApi.Entities.Skill()
            {
                UserId = o.user_id,
                SkillName = o.Skill_name,
                SkillLevel = o.Skill_Level,
                SkillType = o.Skill_Type
            };
        }

        public static Models.EducationDetails EducationMap(FluentApi.Entities.EducationDetail o)
        {
            return new Models.EducationDetails()
            {
                user_id = o.UserId,
                Highest_Graduation = o.HighestGraduation,
                Institute = o.Institute,
                Start_year = o.StartYear,
                End_year = o.EndYear,
                Department = o.Department
            };
        }

        public static FluentApi.Entities.EducationDetail EducationMap(Models.EducationDetails o)
        {
            return new FluentApi.Entities.EducationDetail()
            {
                UserId = o.user_id,
                HighestGraduation = o.Highest_Graduation,
                Institute = o.Institute,
                StartYear = o.Start_year,
                EndYear = o.End_year,
                Department = o.Department
            };
        }
        

        public static IEnumerable<Models.Details> TrainerMap(IEnumerable<FluentApi.Entities.TrainerDetaile> trainer)
        {
            return trainer.Select(TrainerMap);
        }

        public static IEnumerable<Models.Skills> SkillsMap(IEnumerable<FluentApi.Entities.Skill> trainer)
        {
            return trainer.Select(SkillsMap);
        }
        public static IEnumerable<Models.Company> CompanyMap(IEnumerable<FluentApi.Entities.Company> trainer)
        {
            return trainer.Select(CompanyMap);
        }
        public static IEnumerable<Models.EducationDetails> EducationMap(IEnumerable<FluentApi.Entities.EducationDetail> trainer)
        {
            return trainer.Select(EducationMap);
        }

        public static IEnumerable<Models.AllDetails> Map(IEnumerable<FluentApi.TrainerData> datas)
        {
            return datas.Select(Map);
        }
    }
}
