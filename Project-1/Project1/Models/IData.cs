using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public interface IData<T>
    {
        /// <summary>
        /// Add the details 
        /// </summary>
        /// <param name="details"></param>
        /// <returns>Returns the Trainer Details which was added</returns>
        T Add(T details);
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
        List<T> GetAllTrainers();
        /// <summary>
        /// update trainer details in the database
        /// </summary>
        T UpdateTrainer(T details);
        
        /// <summary>
        /// delete the particular trainer details from database
        /// </summary>
        T DeleteTrainer(string name);
        /*/// <summary>
        /// To drop trainer
        /// </summary>
        /// <param name="i"></param>
        void droptrainer(int i);
        /// <summary>
        /// To search trainers By name
        /// </summary>*/
        
        //T SearchByEmail();

        IEnumerable<AllDetails> GetAllDetails();



    }
}
