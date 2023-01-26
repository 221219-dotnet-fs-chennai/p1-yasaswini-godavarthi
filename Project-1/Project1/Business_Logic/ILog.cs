using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainersData;

namespace Business_Logic
{
    public interface ILog
    {
        /// <summary>
        /// This method will return all the trainers  
        /// </summary>
        /// <returns>IEnumerable<Details></Details></returns>
        IEnumerable<Details> GetAllTrainersDisconnected();
        IEnumerable<Details> GetAllTrainersBySkillname(string name);
        /// <summary>
        /// This method will return the details of a trainer
        /// </summary>
        /// <returns></returns>
        Details SearchByEmail();
    }
}
