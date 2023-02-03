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
        /// This method will return all trainers whose skills is matched
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<Details> GetAllTrainersBySkillname(string name);
        /// <summary>
        /// This method will return the details of a trainer
        /// </summary>
        /// <returns></returns>
        IEnumerable<Details> SearchByEmail(string mail);
        /// <summary>
        /// This method will return all trainers whose Experience is matches
        /// </summary>
        /// <param name="Exp"></param>
        /// <returns></returns>
        IEnumerable<Details> SearchByExperience(string Exp);

        TrainerDetaile Add(TrainerDetaile trainer);

    }
}
