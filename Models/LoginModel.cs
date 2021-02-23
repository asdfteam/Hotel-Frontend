using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelLibrary;

namespace Hotel_Frontend.Models
{
    public class LoginModel : LoginRequest
    {

        public new string UserName { get; set; }
        public new string Password { get; set; }
        public string AuthData { get; set; }
        public int CustomerId { get; set; }

        public LoginModel()
        {
        }
        public LoginModel(string username, string password)
        {
            UserName = username;
            Password = password;
            AuthData = null;
        }
    }
}
