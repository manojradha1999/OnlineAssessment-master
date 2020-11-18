using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineAssessmentApplication.DomainModel;
using OnlineAssessmentApplication.Repository;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessmentproject
{
    [TestClass]
    public class AccountControllerTest
    {
        readonly UserRepository userRepository;
        readonly AssessmentDbContext db;
        public AccountControllerTest()
        {
            this.userRepository = new UserRepository();
            this.db = new AssessmentDbContext();
        }
        [TestMethod]
        public void CreateTest()
        {
            
            userRepository.Create(new User() { Name = "Manoj", EmailID = "manojradha@gmail.com",PhoneNumber=8675674243, Password = "123", UserGrade = 2, RoleId = 1 });
            IEnumerable<User> fetchedData = db.Users.Where(temp => temp.EmailID == "manojradha@gmail.com")?.ToList();
            Assert.IsNotNull(fetchedData);

        }
        [TestMethod]
        public void EditTest()
        {
            int id = 6;
            User user = userRepository.Edit(id);
            Assert.IsNotNull(user);
        }
        [TestMethod]
        public void Updatetest()
        {
            bool value = false;
            int id = 6;
            User user = userRepository.Edit(id);
            if(user!=null)
            {
                user.Name = "man";
                userRepository.Update(user);
                value = true;
            }
            Assert.IsTrue(value);

        }
        [TestMethod]
        public void DeleteTest()
        {
            bool value = false;
            int id = 7;
            User user = userRepository.Edit(id);
            if (user != null)
            {
                
                userRepository.Delete(id);
                value = true;
            }
            Assert.IsTrue(value);
        }
    }
}
