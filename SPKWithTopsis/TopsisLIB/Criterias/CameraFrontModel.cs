using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopsisLIB.Criterias
{
    public class CameraFrontModel:Models.CriteriaBase
    {
        private double _start;

        public double Start
        {
            get { return _start; }
            set
            {
                _start = value;
                OnPropertyChange("Start");
            }
        }
        private double _endPrice;

        public double End
        {
            get { return _endPrice; }
            set
            {
                _endPrice = value;
                OnPropertyChange("End");
            }
        }
    }
}
