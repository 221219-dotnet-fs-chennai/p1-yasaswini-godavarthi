using FluentApi.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public interface ILog
    {
        /// <summary>
        /// This method will return all the trainers  
        /// </summary>
        /// <returns>IEnumerable<Details></Details></returns>
        IEnumerable<Details> GetAllTrainers();
        /// <summary>
        /// This method will return all Trainer Skills
        /// </summary>
        /// <returns></returns>
        IEnumerable<Skills> GetAllSkills();
        /// <summary>
        /// This method will return All Education Details
        /// </summary>
        /// <returns></returns>
        IEnumerable<EducationDetails> GetEducationDetails();
        /// <summary>
        /// This method will return all Company details
        /// </summary>
        /// <returns></returns>

        IEnumerable<Models.Company> GetAllCompanies();
        /// <summary>
        /// This mwthod return Trainer detailes whose id is matches
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FluentApi.TrainerData GetTrainerById(int id);
        /// <summary>
        /// This method will return all trainers whose Emailis matches
        /// </summary>
        /// <param name="Exp"></param>
        /// <returns></returns>
        FluentApi.TrainerData SearchByEmail(string email);
        /// <summary>
        /// This method will add new trainer to the database
        /// </summary>
        /// <param name="trainer"></param>
        /// <returns></returns>
        Details Add(Details trainer);
        /// <summary>
        /// This method Add Trainer Education Details
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        EducationDetails AddEdu(EducationDetails e);
        /// <summary>
        /// This method add Trianer Skill details
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        Skills Addskill(Skills s);
        /// <summary>
        /// This method add Company Details
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>

        Models.Company Addcompany(Models.Company c);
        /// <summary>
        /// This method Return all trainers all details
        /// </summary>
        /// <returns></returns>

        IEnumerable<FluentApi.TrainerData> GetAllDetails();
        /// <summary>
        /// This method return all trainers whose skillname matches
        /// </summary>
        /// <param name="skillName"></param>
        /// <returns></returns>
        IEnumerable<FluentApi.TrainerData> GetBySkillName(string skillName);
        /// <summary>
        /// This method return all trainers whose Experience Matches
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        IEnumerable<FluentApi.TrainerData> GetByExperience(string exp);
        /// <summary>
        /// this method return all trainers whose Education matches
        /// </summary>
        /// <param name="hg"></param>
        /// <returns></returns>
        IEnumerable<FluentApi.TrainerData> GetByHg(string hg);
        /// <summary>
        /// this method will updates Trainer details
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="details"></param>
        /// <returns></returns>

        Details UpdateTrainer(string email,string password, Details details);
        /// <summary>
        /// This method will update skill details
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="skill"></param>
        /// <returns></returns>

        Skills UpdateSkill(string email,string password, Skills skill);
        /// <summary>
        /// This method will update Company details
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="company"></param>
        /// <returns></returns>

        Models.Company UpdateCompany(string email,string password,Models.Company company);
        /// <summary>
        /// This method will update education details
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="educationDetail"></param>
        /// <returns></returns>

        EducationDetails UpdateEducation(string email,string password,EducationDetails educationDetail);
        /// <summary>
        /// This methos deletes perticular trainer
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Details DeleteTrainer(string email,string password);
        /// <summary>
        /// This method will checks trainer can login or not
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>

        bool Login(string Email,string Password);

       
    }
}
