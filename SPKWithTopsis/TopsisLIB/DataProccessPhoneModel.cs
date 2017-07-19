using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Models;

namespace TopsisLIB
{
    public class DataProccessPhoneModel
    {
        private List<AlternativeHandPhone> alternatives;
        private List<Criteria> criterias;
        public int cLenght;
        public int aLength;

        public List<Prefensi> prefensis = new List<Models.Prefensi>();

        public List<Bobot> ListBobot = new List<Bobot>();

        public DataProccessPhoneModel(List<Criteria> criterias, List<AlternativeHandPhone> alternatives)
        {
            this.criterias = criterias;
            this.alternatives = alternatives;



            var n = 1;
            foreach (var i in alternatives)
            {
                ListBobot.Add(new Bobot { A = i.Code, C = "C1", Value = i.Harga });
                ListBobot.Add(new Bobot { A = i.Code, C = "C2", Value = i.Storage});
                ListBobot.Add(new Bobot { A = i.Code, C = "C3", Value = i.Ram});
                ListBobot.Add(new Bobot { A = i.Code, C = "C4", Value = i.CamFront});
                ListBobot.Add(new Bobot { A = i.Code, C = "C5", Value = i.CamBack});
                ListBobot.Add(new Bobot { A = i.Code, C = "C5", Value = i.IOS});
                ListBobot.Add(new Bobot { A = i.Code, C = "C5", Value = i.Android});
                n++;

            }

            //Start 

            //prefensi
            foreach (var item in criterias)
            {
                var res = ListBobot.Where(O => O.C == item.Code).Sum(O => O.Value);


                prefensis.Add(new Models.Prefensi { Code = item.Code, Value = res / criterias.Count });
            }


            //Matrix Ternormaliasi

            List<Bobot> ListmatrixTernormaliasi = new List<Bobot>();
            foreach (var item in criterias)
            {
                var res = from a in ListBobot.Where(O => O.C == item.Code)
                          select new Bobot { A = a.A, C = a.C, Value = (a.Value * a.Value) };
                var sumofres = res.Sum(O => O.Value);

                var nor = Math.Sqrt(sumofres);


                foreach (var i in ListBobot.Where(O => O.C == item.Code))
                {
                    ListmatrixTernormaliasi.Add(new Bobot { A = i.A, C = i.C, Value = (i.Value / nor) });
                }

            }

            //Normaliasi Terbobot

            List<Bobot> ListNormalisasiterbobot = new List<Bobot>();
            foreach (var item in criterias)
            {
                var pref = prefensis.Where(O => O.Code == item.Code).FirstOrDefault();
                var res = from a in ListmatrixTernormaliasi.Where(O => O.C == item.Code)
                          select new Bobot { A = a.A, C = a.C, Value = (a.Value * pref.Value) };
                foreach (var i in res)
                {
                    ListNormalisasiterbobot.Add(i);
                }
            }



            List<Bobot> ListMaximum = new List<Bobot>();
            foreach (var item in criterias)
            {
                var res = ListNormalisasiterbobot.Where(O => O.C == item.Code).ToList();

                Bobot b = res.Max<Bobot>();
                ListMaximum.Add(b);

            }

            List<Bobot> ListMinimum = new List<Bobot>();
            foreach (var item in criterias)
            {
                var res = ListNormalisasiterbobot.Where(O => O.C == item.Code).ToList();

                Bobot b = res.Min<Bobot>();
                ListMinimum.Add(b);

            }



            //DPositif


            List<Bobot> DPositif = new List<Bobot>();

            foreach (var item in alternatives)
            {
                var res = ListNormalisasiterbobot.Where(O => O.A == item.Code).ToList();
                double result = 0;
                foreach (var i in res)
                {
                    var max = ListMaximum.Where(O => O.C == i.C).FirstOrDefault();
                    result += (i.Value - max.Value) * (i.Value - max.Value);
                }

                var resend = Math.Sqrt(result);

                DPositif.Add(new Bobot { A = item.Code, Value = resend });

            }


            //DNegatif


            List<Bobot> DNegatif = new List<Bobot>();

            foreach (var item in alternatives)
            {
                var res = ListNormalisasiterbobot.Where(O => O.A == item.Code).ToList();
                double result = 0;
                foreach (var i in res)
                {
                    var min = ListMinimum.Where(O => O.C == i.C).FirstOrDefault();
                    result += (i.Value - min.Value) * (i.Value - min.Value);
                }

                var resend = Math.Sqrt(result);

                DNegatif.Add(new Bobot { A = item.Code, Value = resend });

            }


            //result
            List<Bobot> Results = new List<Bobot>();

            foreach (var item in alternatives)
            {
                var dp = DPositif.Where(O => O.A == item.Code).FirstOrDefault();
                var dn = DNegatif.Where(O => O.A == item.Code).FirstOrDefault();
                double res = dn.Value / (dn.Value + dp.Value);
                item.Value = res;
                Results.Add(new Bobot { A = item.Code, Value = res });
            }


        }
    }
}