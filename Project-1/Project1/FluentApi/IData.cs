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
        /// <summary>
        /// Add Education Details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>

        FluentApi.Entities.EducationDetail AddEdu(FluentApi.Entities.EducationDetail details);
        /// <summary>
        /// Add skill details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>

        Skill Addskill(FluentApi.Entities.Skill details);
        /// <summary>
        /// Add company details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>

        FluentApi.Entities.Company Addcompany(FluentApi.Entities.Company details);
        /// <summary>
        /// To get all the trainers
        /// </summary>
        /// <returns></returns>
        List<FluentApi.Entities.TrainerDetaile> GetAllTrainers();
        /// <summary>
        /// To get all skill details
        /// </summary>
        /// <returns></returns>

        List<FluentApi.Entities.Skill> GetAllSkills();
        /// <summary>
        /// To get all education details
        /// </summary>
        /// <returns></returns>

        List<FluentApi.Entities.EducationDetail> GetEducationDetails();
        /// <summary>
        /// To get all Company details
        /// </summary>
        /// <returns></returns>

        List<FluentApi.Entities.Company> GetAllCompanies();
        /// <summary>
        /// To update perticular trainer details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        FluentApi.Entities.TrainerDetaile UpdateTrainer(FluentApi.Entities.TrainerDetaile details);
        /// <summary>
        /// To update skill details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>

        FluentApi.Entities.Skill UpdateSkill(FluentApi.Entities.Skill details);
        /// <summary>
        /// To update company details
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        FluentApi.Entities.Company UpdateCompany(FluentApi.Entities.Company company);
        /// <summary>
        /// to update Education details
        /// </summary>
        /// <param name="educationDetail"></param>
        /// <returns></returns>

        FluentApi.Entities.EducationDetail UpdateEducation(FluentApi.Entities.EducationDetail educationDetail);
        /// <summary>
        /// delete the particular trainer details from database
        /// </summary>
        FluentApi.Entities.TrainerDetaile DeleteTrainer(string email);
        /// <summary>
        /// To get all trainers all details
        /// </summary>
        /// <returns></returns>
        IEnumerable<TrainerData> GetAllDetails();
        /// <summary>
        /// For trainer Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        bool Login(string username, string password);
        /// <summary>
        /// To get education by id
        /// </summary>
        /// <param name="trainerid"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        EducationDetails edetails(EducationDetails trainerid,int id);

    }
}
