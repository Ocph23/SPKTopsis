using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopsisLIB.Models
{
    public class CriteriaBase:Helpers.BaseNotifyProperty
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value;
                OnPropertyChange("Id");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChange("Name");
            }
        }

        private int _rangking;

        public int Rangking
        {
            get { return _rangking; }
            set { _rangking = value;
                OnPropertyChange("Rangking");
            }
        }



    }
}
