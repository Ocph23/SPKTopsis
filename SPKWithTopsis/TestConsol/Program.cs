using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB;

namespace TestConsol
{
    class Program
    {
        static void Main(string[] args)
        {

            var dal = new DataLayer();

            var proccess = new DataProccess(dal.Criterias, dal.Alternatives);

            proccess.SetBobots(DataLayer.Bobots(dal.Criterias.Count,dal.Alternatives.Count));

            //Bobots


            Console.WriteLine("Bobot");


            for (int i = 0; i < proccess.aLength; i++)
            {
                for (int j = 0; j < proccess.cLenght; j++)
                {
                    Console.Write(string.Format("{0}, ", proccess.Bobots[j,i]));
                }
                Console.WriteLine("");
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");





            Console.WriteLine("Prevensi");

            for (int j = 0; j < proccess.cLenght; j++)
            {
                Console.Write(string.Format("{0}, ", proccess.Prefensi[j]));
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");



            Console.WriteLine("Ternormalisasi");


            for (int i = 0; i < proccess.aLength; i++)
            {
                for (int j = 0; j < proccess.cLenght; j++)
                {
                    Console.Write(string.Format("{0}, ", proccess.MatriksTernormalisasi[j, i]));
                }
                Console.WriteLine("");
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");



            Console.WriteLine("Normalisasi Terbobot");


            for (int i = 0; i < proccess.aLength; i++)
            {
                for (int j = 0; j < proccess.cLenght; j++)
                {
                    Console.Write(string.Format("{0}, ", proccess.NormalisasiTerbobot[j, i]));
                }
                Console.WriteLine("");
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");



            Console.WriteLine("Maximum");

            for (int j = 0; j < proccess.cLenght; j++)
            {
                Console.Write(string.Format("{0}, ", proccess.Maximum[j]));
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");


            Console.WriteLine("Minimum");

            for (int j = 0; j < proccess.cLenght; j++)
            {
                Console.Write(string.Format("{0}, ", proccess.Minimum[j]));
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");



            Console.WriteLine("DPositive");

            for (int j = 0; j < proccess.aLength; j++)
            {
                Console.WriteLine(string.Format("{0}, ", proccess.DPositive[j]));
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");


            Console.WriteLine("DNegative");

            for (int j = 0; j < proccess.aLength; j++)
            {
                Console.WriteLine(string.Format("{0}, ", proccess.DNegative[j]));
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");


            Console.WriteLine("Result");

            for (int j = 0; j < proccess.aLength; j++)
            {
                Console.WriteLine(string.Format("{0}, ", proccess.VResult[j]));
            }
            Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine(""); Console.WriteLine("");



            Console.ReadLine();
        }
    }
}
