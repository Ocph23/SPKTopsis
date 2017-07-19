using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TopsisLIB.Models;

namespace SPKWithTopsis.ViewModels
{
    public class MainWindowVM : TopsisLIB.Helpers.BaseNotifyProperty
    {
        private User _login;
        private Visibility _menu;

        public Visibility MenuVisible
        {
            get { return _menu; }
            set
            {
                _menu = value;
                OnPropertyChange("MenuVisible");
            }
        }

        public User UserLogin
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChange("UserLogin");
            }
        }

        private string _userText;

        public string UserText
        {
            get { return _userText; }
            set { _userText = value;
                OnPropertyChange("UserText");
            }
        }

    }
}
