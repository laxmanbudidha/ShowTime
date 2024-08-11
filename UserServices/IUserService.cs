using Data.Models.Models.Request.Login;
using MyShow.Models.Request.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.UserServices
{
    public interface IUserService
    {
        bool RegisterUser(UserRegistrationRequest request);
        bool LoginUser(LoginModel model);


    }
}
