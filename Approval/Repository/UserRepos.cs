using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Approval.Models;
namespace Approval.Repository
{
    public class UserRepos
    {
        static List<UserModels> users = new List<UserModels>() {

        new UserModels() {Email="abc@gmail.com",Roles="Admin,Editor",Password="abcadmin" },
        new UserModels() {Email="xyz@gmail.com",Roles="Editor",Password="xyzeditor" }
        };

        public static UserModels GetUserDetails(UserModels user)
        {
            return users.Where(u => u.Email.ToLower() == user.Email.ToLower() &&
            u.Password == user.Password).FirstOrDefault();
        }
    }
}