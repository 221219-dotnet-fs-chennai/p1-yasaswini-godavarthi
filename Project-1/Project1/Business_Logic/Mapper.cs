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
        public static Models.Details Map(FluentApi.Entities.TrainerDetaile o)
        {
            return new Models.Details()
            {
                //user_id = o.UserId,
                PASSWORD = o.Password,
                Email = o.Email,
                Full_name = o.FullName,
                Mobile_number = o.MobileNumber,
                Age = Convert.ToInt32(o.Age),
                Gender = o.Gender,
                Website = o.Website, 
            };
        }

        public static Models.Details Map(FluentApi.Entities.Company o)
        {
            return new Models.Details()
            {
                Company_name = o.CompanyName,
                Company_type = o.CompanyType,
                Experience = o.Experience,
                Company_Description = o.CompanyDescription
            };
        }

        public static Models.Details Map(FluentApi.Entities.Skill o)
        {
            return new Models.Details()
            {
                Skill_name = o.SkillName,
                Skill_Level = o.SkillLevel,
                Skill_Type = o.SkillType
            };
        }

        public static Models.Details Map(FluentApi.Entities.EducationDetail o)
        {
            return new Models.Details()
            {
                Highest_Graduation = o.HighestGraduation,
                Institute = o.Institute,
                Start_year = o.StartYear,
                End_year = o.EndYear,
                Department = o.Department
            };
        }

        public static IEnumerable<Models.Details> Map(IEnumerable<FluentApi.Entities.TrainerDetaile> trainer)
        {
            return trainer.Select(Map);
        }

        public static IEnumerable<Models.Details> Map(IEnumerable<FluentApi.Entities.Skill> trainer)
        {
            return trainer.Select(Map);
        }
        public static IEnumerable<Models.Details> Map(IEnumerable<FluentApi.Entities.Company> trainer)
        {
            return trainer.Select(Map);
        }
        public static IEnumerable<Models.Details> Map(IEnumerable<FluentApi.Entities.EducationDetail> trainer)
        {
            return trainer.Select(Map);
        }
    }
}
