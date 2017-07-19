using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopsisLIB.Models
{
    public class Bobot:IComparable
    {
        public string C { get; set; }
        public string A { get; set; }
        public double Value { get; set; }

        public int CompareTo(object obj)
        {
            var a = obj as Bobot;
            return Value.CompareTo(a.Value);
        }
    }
}
