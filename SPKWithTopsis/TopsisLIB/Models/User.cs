using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopsisLIB.Models
{
    [TableName("users")]
    public class User:Helpers.BaseNotifyProperty
    {
        [PrimaryKey("IdUser")]
        [DbColumn("IdUser")]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChange("IdUser");
            }
        }

        [DbColumn("UserName")]
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChange("UserName");
            }
        }

        [DbColumn("Password")]
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChange("Password");
            }
        }

        [DbColumn("UserType")]
        public UserType UserType
        {
            get { return _usertype; }
            set
            {
                _usertype = value;
                OnPropertyChange("UserType");
            }
        }

        public LoginStatus LoginStatus { get; internal set; }

        private int _id;
        private string _username;
        private string _password;
        private UserType _usertype;
    }

}
