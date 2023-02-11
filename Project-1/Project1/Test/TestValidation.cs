using Business_Logic;
using Models;
using FluentApi;
namespace Test
{
    class TestValidation
    {
        [Test]
        [TestCase("9876545678")]
        [TestCase("897688")]

        public void TestPhoneNumber(string phonenumber)
        {
            Assert.AreEqual(Validations.IsValidMobileNumber(phonenumber),phonenumber);
        }
        [Test]
        [TestCase("Yas1")]
        [TestCase("yas1")]
        [TestCase("yasas@")]
        [TestCase("Yasaswini@")]
        public void TestPassword(string password)
        {
            Assert.AreEqual(Validations.IsValidPassword(password), password);
        }
        [Test]
        [TestCase("yasaswini@gmail.com")]
        [TestCase("ebrfghbjbgh")]
        public void TestEmail(string email)
        {
            Assert.AreEqual(Validations.IsValidEmailId(email), email);
        }
    }
}