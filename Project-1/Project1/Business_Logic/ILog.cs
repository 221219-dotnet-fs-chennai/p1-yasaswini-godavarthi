using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainersData;

namespace Business_Logic
{
    internal interface ILog
    {
        IEnumerable<Details> GetAllTrainersDisconnected();

        Details SearchByEmail();
    }
}
