using OnlineAssessmentApplication.DomainModel;
using OnlineAssessmentApplication.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OnlineAssessmentApplication.Repository
{
    /// <summary>
    /// Db side operations for User and Admin are done here.
    /// </summary>
    public interface IUserRepository
    {
        IEnumerable<User> ValidateUser(UserViewModel viewModel);
        //Ienumuerable
        string FindRole(UserViewModel user);
        void Create(User user);
        IEnumerable<User> Display(string serach);
        void Delete(int userId);
        User Edit(int userId);
        void Update(User user);
        bool CheckMailId(string EmailId);
        IEnumerable<Role> RoleDisplay();
    }

    public class UserRepository : IUserRepository
    {
        readonly private AssessmentDbContext db;
        


        public UserRepository()
        {
            db = new AssessmentDbContext();
            
        }
        public IEnumerable<User> ValidateUser(UserViewModel viewModel)
        {
            IEnumerable<User> fetchedData = db.Users.Where(temp => temp.EmailID == viewModel.EmailID && temp.Password == viewModel.Password)?.ToList();
            return fetchedData;
        }
        public string FindRole(UserViewModel user)
        {
            //User
            var role = db.Users.Where(User => User.EmailID == user.EmailID && User.Password == user.Password).FirstOrDefault();
            return role.Role.RoleName;
        }
        public void Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public IEnumerable<User> Display(string serach)
        {

            IEnumerable<User> data = db.Users.Where(User => User.Role.RoleName.ToLower().Contains(serach.ToLower())||serach == null).ToList();
            return (data);


        }
        public void Delete(int userId)
        {

            User user = db.Users.Find(userId);
            db.Users.Remove(user);
            db.SaveChanges();



        }
        public void Update(User user)
        {

            
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();




        }
        public User Edit(int userId)
        {

            User user = db.Users.Find(userId);
            return user;


        }
        public bool CheckMailId(string EmailId)
        {
            
            return db.Users.Where(User => User.EmailID.Contains(EmailId)).ToList().Count == 0;




        }
        public IEnumerable<Role> RoleDisplay()
        {

            IEnumerable<Role> data = db.Roles.ToList();
            return (data);

        }
    }
}
