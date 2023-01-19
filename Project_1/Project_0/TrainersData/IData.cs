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
        /// Add the details into the Details.json File
        /// </summary>
        /// <param name="details"></param>
        /// <returns>Returns the Trainer Details which was added</returns>
        Details Add(Details details);
        bool login(string email);
        /// <summary>
        /// Will return all restaurants in the Restaurant.json file
        /// </summary>
        /// <returns>List of all trainer objects in the collection of Type List<traiiner></returns>
        Details GetAllTrainer(string eMail);
        List<Details> GetAllTrainersDisconnected();
        /// <summary>
        /// update trainer details in the database
        /// </summary>
        void UpdateTrainer(string tableName, string columnName,string newValue, int user_id);

        /// <summary>
        /// delete the particular trainer details from database
        /// </summary>
        void DeleteTrainer(string eMail);
    }
}
