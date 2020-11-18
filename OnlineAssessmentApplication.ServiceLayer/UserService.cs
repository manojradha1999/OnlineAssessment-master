using AutoMapper;
using OnlineAssessmentApplication.DomainModel;
using OnlineAssessmentApplication.Repository;
using OnlineAssessmentApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineAssessmentApplication.ServiceLayer
{
 /// <summary>
/// Passing the values from Accountcontroller to UserRepository.
/// </summary>
    public interface IUserService
    {
        UserViewModel ValidateUser(UserViewModel user);
        void Create(User user);
        void Delete(int userId);
        User Edit(int userId);

        void Update(User user);
        IEnumerable<User> Display(string serach);
        bool CheckMailId(string EmailId);
        IEnumerable<Role> RoleDisplay();
        long GenerateRandomNumber();

        string FindRole(UserViewModel user);
    }
    public class UserService : IUserService
    {
        readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public UserViewModel ValidateUser(UserViewModel user)
        {
            User fetchedData = null;
            fetchedData= userRepository.ValidateUser(user).FirstOrDefault();
            UserViewModel sensitiveData = null;
            if (fetchedData != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                sensitiveData = mapper.Map<User, UserViewModel>(fetchedData);
            }
            return sensitiveData;


        }
        public string FindRole(UserViewModel user)
        {
            return userRepository.FindRole(user);

        }
        public void Create(User user)
        {
            user.CreatedDate = DateTime.Now.Date;
            userRepository.Create(user);
        }
        public void Delete(int userId)
        {
            userRepository.Delete(userId);
        }
        public User Edit(int userId)
        {
            return userRepository.Edit(userId);
        }
        public void Update(User user)
        {
            
            user.ModifiedDate = DateTime.Now.Date;
            userRepository.Update(user);
        }

        public IEnumerable<User> Display(string serach)
        {
            return userRepository.Display(serach);
        }

        public bool CheckMailId(string EmailId)
        {
            return (userRepository.CheckMailId(EmailId));
        }

        public long GenerateRandomNumber()
        {
            Random random = new Random();
            long number = random.Next(11000, 19000);
            return number;
        }
        public IEnumerable<Role> RoleDisplay()
        {
            return (userRepository.RoleDisplay());
        }
    }
}
