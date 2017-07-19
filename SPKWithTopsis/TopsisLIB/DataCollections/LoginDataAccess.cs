using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Models;

namespace TopsisLIB.DataCollections
{
    public   class LoginDataAccess
    {
      

        public User Login(string user, string password)
        {
            if (UserIsEmpty())
            {
                using (var db = new OcphDbContext())
                {
                    var item = new User { Password = password, UserName = user, UserType = UserType.Administrator, Id = 0 };
                  var isSaved=  this.Add(item);
                    if(isSaved)
                    {
                        item.LoginStatus = LoginStatus.FirstUser;
                        return item;
                    }else
                    {
                        item.LoginStatus = LoginStatus.LoginError;
                        return item;
                    }
                }
               
            }else
            {
                using (var db = new OcphDbContext())
                {
                    var u = db.Users.Where(O => O.UserName == user && O.Password == password).FirstOrDefault();
                    if (u != null)
                    {
                        u.LoginStatus = LoginStatus.LoginSuccess;
                        return u;
                    }
                    else
                    {
                        u = new User { LoginStatus = LoginStatus.LoginError };
                        return u;
                    }
                }
            }
        }

        private bool UserIsEmpty()
        {
            using (var db = new OcphDbContext())
            {
                var res = db.Users.Select().ToList();
                if (res.Count <= 0)
                {
                    return true;

                }
                else
                    return false;
            }
        }

        public bool Add(User user)
        {
            using (var db = new OcphDbContext())
            {
                return db.Users.Insert(user);
            }
        }





    }
}
