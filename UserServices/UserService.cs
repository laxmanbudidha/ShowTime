using Data.Models.Models.Request.Login;
using Data_Access_Layer.UserServices;
using MyShow.Models.Request.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool RegisterUser(UserRegistrationRequest userrequest)
        {
            try
            {
                if (_userRepository.GetByUsername(userrequest))
                {
                    return false; // User already exists
                }

                var user = new UserRegistrationRequest
                {
                    UserName = userrequest.UserName,
                    Password = userrequest.Password,
                    Email = userrequest.Email

                    //PasswordHash = BCrypt.Net.BCrypt.HashPassword(password), // Use a secure hash function

                };

                _userRepository.Add(user);
                return true;
            }
            catch {
                return false;
            }
           
        }

        public bool LoginUser(LoginModel model)
        {
            try
            {
                var message = _userRepository.LoginUser(model);
                return message == "Login successful";
            }
            catch (Exception ex) 
            {
                return false;
            }
           
        }
        
    }
}
