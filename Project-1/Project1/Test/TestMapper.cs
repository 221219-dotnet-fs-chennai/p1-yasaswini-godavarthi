using Business_Logic;
using Models;
using FluentApi;
using System.Reflection;
using FluentApi.Entities;

namespace Test
{
    public class TestMapper
    {
        [Test]
        public void TestSkillMap()
        {
            Skills s= new Skills();
            var skill = Mapper.SkillsMap(s);
            Assert.AreEqual(skill.GetType(), typeof(Skill));
        }
        [Test]
        public void TestCompanymap()
        {
            Models.Company c = new Models.Company();
            var company = Mapper.CompanyMap(c);
            Assert.AreEqual(company.GetType(), typeof(FluentApi.Entities.Company));
        }
        [Test]
        public void TestEducationmap()
        {
            Models.EducationDetails e = new Models.EducationDetails();
            var edu= Mapper.EducationMap(e);
            Assert.AreEqual(edu.GetType(), typeof(FluentApi.Entities.EducationDetail));
        }
        [Test]
        public void TestTrainer()
        {
            TrainerDetaile c = new TrainerDetaile();
            var details = Mapper.TrainerMap(c);
            Assert.AreEqual(details.GetType(), typeof(Details));
        }
    }
}
