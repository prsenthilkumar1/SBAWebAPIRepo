using SBAWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBAWebAPI.Controllers
{
    public class UserAPIController : ApiController
    {
        

        // GET: api/UserAPI 
        public List<UserModel> Get()
        {

            //List<UserModel> l_user = new List<UserModel>()
            //        {
            //            new UserModel(){ UserID = 1,  EmployeeID = "A64", FirstName = "Senthil", LastName = "Kumar", Role = "M" },
            //            new UserModel(){ UserID = 2,  EmployeeID = "A61", FirstName = "Goutham", LastName = "K", Role = "M" },
            //            new UserModel(){ UserID = 3,  EmployeeID = "A62", FirstName = "Krishna", LastName = "A", Role = "M" },
            //        };

            List<UserModel> l_UserModels = new List<UserModel>();

            using (masterEntities mstEntities = new masterEntities())
            {
                List<User> l_user = new List<User>();
                l_user = mstEntities.Users.Select(x => x).ToList();

                if (l_user?.Count > 0)
                {
                    foreach (var user in l_user)
                    {
                        UserModel userModel = new UserModel();
                        userModel.EmployeeID = user.EmployeeID;
                        userModel.FirstName = user.FirstName;
                        userModel.LastName = user.LastName;
                        userModel.Role = user.Role;
                        userModel.UserID = user.User_ID;

                        l_UserModels.Add(userModel);
                    }
                }
            };

            return l_UserModels;
        }

        // GET: api/UserAPI/5 
        public string Get(int id)
        {
            return null;
        }

        // POST: api/UserAPI 
        public string Post(UserModel userModel)
        {
            string success = string.Empty;

            using (masterEntities mstEntities = new masterEntities())
            {
                User user = new User();
                //UserModel user = new UserModel();
                user.EmployeeID = userModel.EmployeeID;
                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Role = userModel.Role;
                user.User_ID = userModel.UserID;

                //l_user.Add(user);

                mstEntities.Users.Add(user);
                mstEntities.SaveChanges();
            }

            success = "User Details successfully saved";

            return success;
        }

        // PUT: api/UserAPI
        public string Put(UserModel userModel)
        {
            string success = string.Empty;

            using (masterEntities mstEntities = new masterEntities())
            {
                User user = new User();

                user = mstEntities.Users.Where(t => t.User_ID == userModel.UserID).Select(x => x).FirstOrDefault();

                //user = l_user.Where(t => t.UserID == userModel.UserID).Select(x => x).FirstOrDefault();

                if (user != null)
                {
                    user.EmployeeID = userModel.EmployeeID;
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.Role = userModel.Role;

                    //l_user.Remove(user);
                    //l_user.Add(user);

                    mstEntities.Entry(user).State = EntityState.Modified;
                    mstEntities.SaveChanges();
                }
            };

            success = "User Details successfully Updated";
            return success;
        }

        // DELETE: api/UserAPI/5 
        public string Delete(UserModel userModel)
        {
            string success = string.Empty;

            using (masterEntities mstEntities = new masterEntities())
            {
                User user = new User();

                user = mstEntities.Users.Where(t => t.User_ID == userModel.UserID).Select(x => x).FirstOrDefault();

                //user = l_user.Where(t => t.UserID == userModel.UserID).Select(x => x).FirstOrDefault();

                if (user != null)
                {
                    //l_user.Remove(user);

                    mstEntities.Entry(user).State = EntityState.Deleted;
                    mstEntities.SaveChanges();
                }
            };

            return success;
        }        
    }
}
