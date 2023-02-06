using FluentApi.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        /// To login to the application
        /// </summary>
        /// <param name="email"></param>
        /// <returns>to do crud opearations</returns>
       /* bool login(string email);
        /// <summary>
        /// Will return all trainers 
        /// </summary>
        /// <returns>List of all trainer objects in the collection of Type List<traiiner></returns>
        T GetAllTrainer(string email);*/
        List<FluentApi.Entities.TrainerDetaile> GetAllTrainers();
        /// <summary>
        /// update trainer details in the database
        /// </summary>
        FluentApi.Entities.TrainerDetaile UpdateTrainer(FluentApi.Entities.TrainerDetaile details);
        
        /// <summary>
        /// delete the particular trainer details from database
        /// </summary>
        FluentApi.Entities.TrainerDetaile DeleteTrainer(string name);
        /*/// <summary>
        /// To drop trainer
        /// </summary>
        /// <param name="i"></param>
        void droptrainer(int i);
        /// <summary>
        /// To search trainers By name
        /// </summary>*/
        
        //T SearchByEmail();

        IEnumerable<TrainerData> GetAllDetails();

        bool Login(string username, string password);
        EducationDetails edetails(EducationDetails trainerid,int id);

       // FluentApi.Entities.Company UTrainer(FluentApi.Entities.Company c);

    }
}
