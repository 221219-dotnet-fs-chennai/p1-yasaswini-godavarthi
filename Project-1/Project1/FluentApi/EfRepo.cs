using FluentApi.Entities;
using Models;

namespace FluentApi
{
    public class EfRepo : IData
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
        public Entities.EducationDetail AddEdu(Entities.EducationDetail details)
        {
            _context.EducationDetails.Add(details);
            _context.SaveChanges();
            return details;
        }

        public Skill Addskill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return skill;

        }

        public Entities.Company Addcompany(Entities.Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return company;
        }

        public List<Entities.Skill> GetAllSkills()
        {
            return _context.Skills.ToList();
        }

        public List<Entities.EducationDetail> GetEducationDetails()
        {
            return _context.EducationDetails.ToList();
        }

        public List<Entities.Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }
        public List<Entities.TrainerDetaile> GetAllTrainers()
        {
            return _context.TrainerDetailes.ToList();
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

        public Skill UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
            return skill;
        }

        public FluentApi.Entities.Company UpdateCompany(FluentApi.Entities.Company company) 
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
            return company;
        }

        public FluentApi.Entities.EducationDetail UpdateEducation(FluentApi.Entities.EducationDetail educationDetail)
        {
            _context.EducationDetails.Update(educationDetail);
            _context.SaveChanges();
            return educationDetail;
        }

        public Entities.TrainerDetaile DeleteTrainer(string email)
        {
            var s = _context.TrainerDetailes.Where(T=>T.Email == email).FirstOrDefault();
            int k = s.UserId;
            var e = _context.EducationDetails.Where(T=>T.UserId == k).FirstOrDefault();
            var c = _context.Companies.Where(T=>T.UserId == k).FirstOrDefault();
            var sk = _context.Skills.Where(T=>T.UserId== k).FirstOrDefault(); 
            if (s != null)
            {
                if (e != null)
                {
                    _context.EducationDetails.Remove(e);
                }
                if (c != null)
                {
                    _context.Companies.Remove(c);
                }
                if (sk != null)
                {
                    _context.Skills.Remove(sk);
                }
                if (s != null)
                {
                    _context.TrainerDetailes.Remove(s);
                }
                _context.SaveChanges();
            }
            return s;
        }

        public IEnumerable<TrainerData> GetAllDetails()
        {
            var tdetails = _context.TrainerDetailes;
            var edetails = _context.EducationDetails;
            var sdetails = _context.Skills;
            var cdetails = _context.Companies;

            var alldetails = (from t in tdetails
                              join e in edetails on t.UserId equals e.UserId
                              join s in sdetails on e.UserId equals s.UserId
                              join c in cdetails on s.UserId equals c.UserId
                              select new TrainerData()
                              {
                                  user_id = t.UserId,
                                  PASSWORD= t.Password,
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

        public bool Login(string username, string password)
        {
            var r = _context.TrainerDetailes;
            var q = r.FirstOrDefault(v => v.Email == username);

            if (q != null)
            {
                var tara= r.FirstOrDefault(val => val.Password == password);
                if (tara != null)
                {
                    Console.WriteLine("Successfully Logined");
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong Password try again....");
                    Console.WriteLine("Enter to continue...");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Check your Credentials");
                return false;
            }


        }

        public EducationDetails edetails(EducationDetails trainerid,int id)
        {
            //throw new NotImplementedException();
            var t = _context.EducationDetails;
            var h=from s in t
                  where s.UserId==id

                  select s;

            EducationDetails e = new EducationDetails();
            foreach(var s in t)
            {
                e = new EducationDetails()
                {
                    Institute = s.Institute,
                    Department = s.Department,
                    End_year = s.EndYear,
                    Start_year = s.StartYear,
                    Highest_Graduation = s.HighestGraduation,
                };
            }
            return e;
        }

    }
}