using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StonksWeb
{
    public class User
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;

        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}