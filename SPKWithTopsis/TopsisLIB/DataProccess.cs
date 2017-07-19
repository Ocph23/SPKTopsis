using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Models;

namespace TopsisLIB
{
    public class DataProccess
    {
        private List<Alternatif> alternatives;
        private List<Criteria> criterias;
        public int cLenght;
        public int aLength;

        public DataProccess(List<Criteria> criterias, List<Alternatif> alternatives)
        {
            this.criterias = criterias;
            this.alternatives = alternatives;
            this.cLenght = criterias.Count;
            this.aLength = alternatives.Count;
        }

        public void SetBobots(double[,] v)
        {
            this.Bobots = v;
            ProccessPrevensi();
            this.ProccessMatriksTernormalisasi();
            ProccessNormalisasiTerbobot();
            ProccessMaximum();
            ProccessMinimum();
            ProcesDPositive();
            ProcesDNegative();
            ProccessVResult();
        }

        //step1 



        private void ProccessPrevensi()
        {
            var pref = new double[cLenght];

            for (int j = 0; j < cLenght; j++)
            {
                double l = 0;
                for (int i = 0; i < aLength; i++)
                {
                    l += Bobots[j,i];
                }

                pref[j] = l / pref.Length;
            }
            this.Prefensi= pref;
            /*tambahan

            Prefensi[0] = 4;
            Prefensi[1] = 5;
            Prefensi[2] = 3;
            Prefensi[3] = 5;
            Prefensi[4] = 2;
            */

        }


        //step2
        private void ProccessMatriksTernormalisasi()
        {
            var nor = new double[cLenght];

            var result = new double[cLenght, aLength];

            for (int j = 0; j < cLenght; j++)
            {
                double l = 0;
                for (int i = 0; i <aLength; i++)
                {
                    var val = Bobots[j,i];
                    l += (val * val);

                }

                nor[j] = Math.Sqrt(l);
                for (int i = 0; i < aLength; i++)
                {
                    var val = Bobots[j, i];
                    result[j, i] = val / nor[j];

                }
            }
            this.MatriksTernormalisasi = result;
        }

        public void ProccessNormalisasiTerbobot()
        {
            var result = new double[cLenght, aLength];
            for (int j = 0; j < cLenght; j++)
            {
                for (int i = 0; i < aLength; i++)
                {
                    var val = MatriksTernormalisasi[j, i];
                    var l = val * Prefensi[j];
                    result[j, i] = l;
                }
            }
            this.NormalisasiTerbobot = result;
        }

        public  void ProccessMaximum()
        {
            var result = new double[cLenght];
            for (int j = 0; j < cLenght; j++)
            {
                var temp = new double[aLength];
                for (int i = 0; i < aLength; i++)
                {
                    temp[i] = NormalisasiTerbobot[j, i];
                }
                result[j] = Max(temp);
            }

            this.Maximum = result;
        }

        public void ProccessMinimum()
        {
            var result = new double[cLenght];
            for (int j = 0; j < cLenght; j++)
            {
                var temp = new double[aLength];
                for (int i = 0; i < aLength; i++)
                {
                    temp[i] = NormalisasiTerbobot[j, i];
                }
                result[j] = Min(temp);
            }

            this.Minimum= result;
        }



        public void ProcesDPositive()
        {
            var result = new double[aLength];
            for (var j = 0; j < aLength; j++)
            {
                double r = 0;
                for (var z = 0; z < cLenght; z++)
                {
                    r += (NormalisasiTerbobot[z, j] - Maximum[z]) * (NormalisasiTerbobot[z, j] - Maximum[z]);
                }

                result[j] = Math.Sqrt( r);
            }

            this.DPositive = result;
            
        }

        public void ProcesDNegative()
        {
            var result = new double[aLength];
            for (var j = 0; j < aLength; j++)
            {
                double r = 0;
                for (var z = 0; z < cLenght; z++)
                {
                    r += (NormalisasiTerbobot[z,j] - Minimum[z]) * (NormalisasiTerbobot[z,j] - Minimum[z]);
                }

                result[j] =Math.Sqrt( r);
            }

            this.DNegative = result;

        }

        public void ProccessVResult()
        {
            var result = new double[aLength];
            for(var i=0;i<aLength;i++)
            {
                var r = DNegative[i] / (DNegative[i] + DPositive[i]);
                result[i] = r;
            }

            this.VResult = result;
        }



        public double[,] Bobots { get; set; }
        public double[] Prefensi { get; private set; }
        public double[,] MatriksTernormalisasi { get; private set; }
        public double[,] NormalisasiTerbobot { get; private set; }
        public double[] Maximum { get; private set; }
        public double[] Minimum { get; private set; }
        public double[] DPositive { get; private set; }
        public double[] DNegative { get; private set; }
        public double[] VResult { get; private set; }

        //helper


        public  double Max(double[] data)
        {
            double result = 0;
            for (int i = 0; i < data.Length; i++)
            {
                var d = data[i];
                if (d > result)
                {
                    result = d;
                }
            }

            return result;

        }

        public  double Min(double[] data)
        {
            double result = 0;

            for (int i = 0; i < data.Length; i++)
            {
                var d = data[i];
                if (i == 0)
                {
                    result = d;
                }

                if (d < result)
                {
                    result = d;
                }
            }

            return result;

        }
    }
}
