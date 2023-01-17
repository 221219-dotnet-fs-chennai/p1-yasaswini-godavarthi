using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public interface IAlldetails
    { 
           
            void Display();

            /// <summary>
            /// Will record the user's choice and change/route y
            /// </summary>
            /// <returns>Return the data that will change your screen</returns>
            string UserChoice();
    }
}
