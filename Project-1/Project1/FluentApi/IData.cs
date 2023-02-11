using FluentApi.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace FluentApi
{
    public interface IData
    {
        /// <summary>
        /// Add the details 
        /// </summary>
        /// <param name="details"></param>
        /// <returns>Returns the Trainer Details which was added</returns>
        FluentApi.Entities.TrainerDetaile Add(FluentApi.Entities.TrainerDetaile details);

        FluentApi.Entities.EducationDetail AddEdu(FluentApi.Entities.EducationDetail details);

        Skill Addskill(FluentApi.Entities.Skill details);

        FluentApi.Entities.Company Addcompany(FluentApi.Entities.Company details);
        List<FluentApi.Entities.TrainerDetaile> GetAllTrainers();

        List<FluentApi.Entities.Skill> GetAllSkills();

        List<FluentApi.Entities.EducationDetail> GetEducationDetails();

        List<FluentApi.Entities.Company> GetAllCompanies();
        /// <summary>
        /// update trainer details in the database
        /// </summary>
        FluentApi.Entities.TrainerDetaile UpdateTrainer(FluentApi.Entities.TrainerDetaile details);

        FluentApi.Entities.Skill UpdateSkill(FluentApi.Entities.Skill details);

        FluentApi.Entities.Company UpdateCompany(FluentApi.Entities.Company company);

        FluentApi.Entities.EducationDetail UpdateEducation(FluentApi.Entities.EducationDetail educationDetail);

        /// <summary>
        /// delete the particular trainer details from database
        /// </summary>
        FluentApi.Entities.TrainerDetaile DeleteTrainer(string name);

        IEnumerable<TrainerData> GetAllDetails();

        bool Login(string username, string password);
        EducationDetails edetails(EducationDetails trainerid,int id);

       // FluentApi.Entities.Company UTrainer(FluentApi.Entities.Company c);

    }
}
