using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopsisLIB.Criterias
{
    public class LcdModel : Models.CriteriaBase
    {
        private double _value;

        public double Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChange("Value"); }
        }
    }
}
