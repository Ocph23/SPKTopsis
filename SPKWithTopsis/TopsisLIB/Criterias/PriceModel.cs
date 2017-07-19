using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopsisLIB.Criterias
{
    public class PriceModel:Models.CriteriaBase
    {
        private double _start;

        public double StartPrice
        {
            get { return _start; }
            set { _start = value;
                OnPropertyChange("StartPrice");
            }
        }
        private double _endPrice;

        public double EndPrice
        {
            get { return _endPrice; }
            set { _endPrice = value;
                OnPropertyChange("EndPrice");
            }
        }


    }
}
