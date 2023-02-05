using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class SkillLogic:ISkills
    {
        private readonly ISkills _repo;
        public SkillLogic(ISkills repo)
        {
            _repo = repo;
        }

        public IEnumerable<Skills> GetSkills(Details details)
        {
           throw new NotImplementedException();
           // return Mapper.SkillsMap(_repo.GetSkills(Mapper.TrainerMap(details)));
        }

    }
}
