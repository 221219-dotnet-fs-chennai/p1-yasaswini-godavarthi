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
        public static Models.Details TrainerMap(FluentApi.Entities.TrainerDetaile o)
        {
            return new Models.Details()
            {
                user_id = o.UserId,
                //PASSWORD = Validations.IsValidPassword(o.Password),
                Email = Validations.IsValidEmailId(o.Email),
                Full_name = o.FullName,
                Mobile_number = Validations.IsValidMobileNumber(o.MobileNumber),
                Age = Convert.ToInt32(o.Age),
                Gender = o.Gender,
                Website = o.Website, 
            };
        }

        public static FluentApi.Entities.TrainerDetaile TrainerMap(Models.Details o)
        {
            return new FluentApi.Entities.TrainerDetaile()
            {
                UserId = o.user_id,
                //PASSWORD = Validations.IsValidPassword(o.Password),
                Email = Validations.IsValidEmailId(o.Email),
                FullName = o.Full_name,
                MobileNumber = Validations.IsValidMobileNumber(o.Mobile_number),
                Age = Convert.ToInt32(o.Age),
                Gender = o.Gender,
                Website = o.Website,
            };
        }

        public static Models.Company CompanyMap(FluentApi.Entities.Company o)
        {
            return new Models.Company()
            {
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
                Skill_name = o.SkillName,
                Skill_Level = o.SkillLevel,
                Skill_Type = o.SkillType
            };
        }

        public static FluentApi.Entities.Skill SkillsMap(Models.Skills o)
        {
            return new FluentApi.Entities.Skill()
            {
                SkillName = o.Skill_name,
                SkillLevel = o.Skill_Level,
                SkillType = o.Skill_Type
            };
        }

        public static Models.EducationDetails EducationMap(FluentApi.Entities.EducationDetail o)
        {
            return new Models.EducationDetails()
            {
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
    }
}
