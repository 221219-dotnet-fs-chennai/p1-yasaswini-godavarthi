using FluentApi.Entities;
using Models;

namespace FluentApi
{
    public class EfRepo : IData<Entities.TrainerDetaile>
    {
        private readonly TrainerDbContext _context;
        public EfRepo(TrainerDbContext context)
        {
            _context = context;
        }
        public Entities.TrainerDetaile Add(Entities.TrainerDetaile details)
        {
            _context.Add(details);
            _context.SaveChanges();
            return details;
        }


        public void droptrainer(int i)
        {
            throw new NotImplementedException();
        }

        public Entities.TrainerDetaile GetAllTrainer(string email)

        {
            throw new NotImplementedException();
        }

        public List<Entities.TrainerDetaile> GetAllTrainers()
        {
            return _context.TrainerDetailes.ToList();
        }

        public bool login(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.TrainerDetaile> SearchByEmail()
        {
            return _context.TrainerDetailes.ToList();

        }

        public TrainerDetaile UpdateTrainer(TrainerDetaile details)
        {
            _context.TrainerDetailes.Update(details);
            _context.SaveChanges();
            return details;
        }

        public Entities.TrainerDetaile DeleteTrainer(string name)
        {
            var s = _context.TrainerDetailes.Where(T=>T.FullName== name).FirstOrDefault();
            if (s != null)
            {
                _context.TrainerDetailes.Remove(s);
                _context.SaveChanges();
            }
            return s;
        }

        public IEnumerable<AllDetails> GetAllDetails()
        {
            var tdetails = _context.TrainerDetailes;
            var edetails = _context.EducationDetails;
            var sdetails = _context.Skills;
            var cdetails = _context.Companies;

            var alldetails = (from t in tdetails
                              join e in edetails on t.UserId equals e.UserId
                              join s in sdetails on e.UserId equals s.UserId
                              join c in cdetails on s.UserId equals c.UserId
                              select new AllDetails()
                              {
                                  Email = t.Email,
                                  Full_name = t.FullName,
                                  Age = (int)t.Age,
                                  Gender = t.Gender,
                                  Mobile_number = t.MobileNumber,
                                  Website = t.Website,
                                  Company_name = c.CompanyName,
                                  Company_type = c.CompanyType,
                                  Company_Description = c.CompanyDescription,
                                  Experience = c.Experience,
                                  Skill_name = s.SkillName,
                                  Skill_Type = s.SkillType,
                                  Skill_Level = s.SkillLevel,
                                  Highest_Graduation = e.HighestGraduation,
                                  Start_year = e.StartYear,
                                  End_year = e.EndYear,
                                  Department = e.Department,
                                  Institute = e.Institute
                              });
            return alldetails.ToList();
        }
    }
}