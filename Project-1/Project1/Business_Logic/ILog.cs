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
        /// This method will return trainer whose email is matched
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Details GetTrainerById(int id);
        /// <summary>
        /// This method will return all trainers whose Emailis matches
        /// </summary>
        /// <param name="Exp"></param>
        /// <returns></returns>
        IEnumerable<Details> SearchByEmail(string email);

        Details Add(Details trainer);

        Details UpdateTrainer(string name, Details details);
    }
}
