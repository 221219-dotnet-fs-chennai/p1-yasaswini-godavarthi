using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public interface ISkills
    {
        IEnumerable<Skills> GetSkills(Details details);
    }
}
