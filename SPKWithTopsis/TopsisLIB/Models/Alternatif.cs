using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopsisLIB.Models
{
    public class Alternatif
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int Harga { get;  set; }
        public int Hardisk { get; set; }
        public int ProccesorCode { get; set; }
        public int RAMCode { get; set; }
        public int LCD { get; set; }
    }

  


    public class AlternativeHandPhone
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int Harga { get; set; }
        public int Storage { get; set; }
        public int Ram { get; set; }
        public int CamFront { get; set; }
        public int CamBack { get; set; }
        public int IOS { get; set; }
        public int Android { get; set; }
}


    public class Criteria
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Bobot { get; set; }
    }
}
