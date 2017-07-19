using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopsisLIB.Criterias
{
   public  class HardiskModel:Models.CriteriaBase
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChange("Value"); }
        }

    }
}
