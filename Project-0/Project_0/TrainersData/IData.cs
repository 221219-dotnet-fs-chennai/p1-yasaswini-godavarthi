using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersData
{
    public interface IData
    {
        /// <summary>
        /// Add the details 
        /// </summary>
        /// <param name="details"></param>
        /// <returns>Returns the Trainer Details which was added</returns>
        Details Add(Details details);
        /// <summary>
        /// To login to the application
        /// </summary>
        /// <param name="email"></param>
        /// <returns>to do crud opearations</returns>
        bool login(string email);
        /// <summary>
        /// It is used for login 
        /// <param name="email";
        /// </summary>
        /// <returns>List of all trainer objects in the collection of Type List<traiiner></returns>
        Details GetAllTrainer(string email);
        /// <summary>
        /// To get all the traianers
        /// </summary>
        /// <returns>Returns all trainers details</returns>
        List<Details> GetAllTrainersDisconnected();
        /// <summary>
        /// update trainer details in the database
        /// </summary>
        void UpdateTrainer(string tableName, string columnName,string newValue, int user_id);

        /// <summary>
        /// delete the particular trainer details from database
        /// </summary>
        void DeleteTrainer(string col,string table, int user);
        /// <summary>
        /// To drop trainer
        /// </summary>
        /// <param name="i"></param>
        void droptrainer(int i);
        /// <summary>
        /// To search trainers By name
        /// </summary>
        
        Details SearchByEmail();


    }
}
