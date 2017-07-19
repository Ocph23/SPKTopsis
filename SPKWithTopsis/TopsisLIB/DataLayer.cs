using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Criterias;
using TopsisLIB.Models;

namespace TopsisLIB
{
    public class DataLayer
    {
        public  List<Criteria> Criterias { get; set; }

        public  List<Alternatif> Alternatives { get; set; }

        public List<Criterias.ProccesorModel> Proccessors { get; set; }

        public List<Criterias.PriceModel> Prices { get; set; }

        public List<Criterias.HardiskModel> Hardisks { get; set; }

        public List<Criterias.RamModel> Rams { get; set; }


        public List<Criterias.LcdModel> Lcds { get; set; }

        public List<Criterias.CameraBackModel> CamBacks { get; set; }
        public List<Criterias.CameraFrontModel> CamFronts { get; set; }
        public List<Criterias.OsModel> OSs { get; set; }

        public List<Criterias.StoregeModel> Storages { get; set; }



        public DataLayer()
        {
            
            Proccessors = new List<ProccesorModel>();
            Prices = new List<PriceModel>();
            Hardisks = new List<HardiskModel>();
            Rams = new List<RamModel>();
            Lcds = new List<LcdModel>();
            //Laptop 
            Proccessors.Add(new ProccesorModel { Id = 1, Name = "Core 2 Dou", Rangking = 1 });
            Proccessors.Add(new ProccesorModel { Id = 2, Name = "Core i3", Rangking = 2 });
            Proccessors.Add(new ProccesorModel { Id = 3, Name = "NVidia Tegra T30 Quad Core", Rangking = 3 });
            Proccessors.Add(new ProccesorModel { Id = 4, Name = "Core i5", Rangking = 4 });
            Proccessors.Add(new ProccesorModel { Id = 5, Name = "Core i7", Rangking = 5 });


            Prices.Add(new PriceModel { Id = 1, Name = "> 9 Juta", StartPrice = 9000000, EndPrice = 100000000, Rangking = 1 });
            Prices.Add(new PriceModel { Id = 2, Name = "7-8 Juta", StartPrice = 7000000, EndPrice = 9000000, Rangking = 2 });
            Prices.Add(new PriceModel { Id = 3, Name = "6-7 Juta", StartPrice = 6000000, EndPrice = 7000000, Rangking = 3 });
            Prices.Add(new PriceModel { Id = 4, Name = "5-6 Juta", StartPrice = 5000000, EndPrice = 6000000, Rangking = 4 });
            Prices.Add(new PriceModel { Id = 5, Name = "< 4 Juta", StartPrice = 0, EndPrice = 5000000, Rangking = 5 });

            Hardisks.Add(new HardiskModel { Id = 1, Name = "64 GB", Value = 64, Rangking = 1 });
            Hardisks.Add(new HardiskModel { Id = 2, Name = "128 GB", Value = 128, Rangking = 2 });
            Hardisks.Add(new HardiskModel { Id = 3, Name = "250 GB", Value = 250, Rangking = 3 });
            Hardisks.Add(new HardiskModel { Id = 4, Name = "320 GB", Value = 320, Rangking = 4 });
            Hardisks.Add(new HardiskModel { Id = 5, Name = "500 GB", Value = 500, Rangking = 5 });

            Rams.Add(new RamModel { Id = 1, Name = "2 GB DDR3", Value = 2, Rangking = 1 });
            Rams.Add(new RamModel { Id = 2, Name = "4 GB DDR3", Value = 4, Rangking = 2});

            Lcds.Add(new LcdModel { Id = 1, Name = "15.6 Inc", Value = 16.6, Rangking = 1 });
            Lcds.Add(new LcdModel { Id = 2, Name = "12 Inc", Value = 16.6, Rangking = 2 });
            Lcds.Add(new LcdModel { Id = 3, Name = "10.1 Inc", Value = 16.6, Rangking = 3 });
            Lcds.Add(new LcdModel { Id = 4, Name = "13 Inc", Value = 16.6, Rangking = 4 });
            Lcds.Add(new LcdModel { Id = 5, Name = "14 Inc", Value = 16.6, Rangking = 5 });


            Criterias = new List<Criteria>();
            Criterias.Add(new Criteria { Id = 1, Code = "C1", Name = "Harga", Bobot = 5 });
            Criterias.Add(new Criteria { Id = 2, Code = "C2", Name = "Hardisk", Bobot = 3 });
            Criterias.Add(new Criteria { Id = 3, Code = "C3", Name = "Procecor", Bobot = 4 });
            Criterias.Add(new Criteria { Id = 4, Code = "C4", Name = "Ram", Bobot = 4 });
            Criterias.Add(new Criteria { Id = 5, Code = "C5", Name = "LCD", Bobot = 2 });



            //Handphone Data

            this.Storages = new List<StoregeModel>();

            this.Storages.Add(new StoregeModel { Id = 1, Name = "2 GB", Rangking = 1 });
            this.Storages.Add(new StoregeModel { Id = 2, Name = "4 GB", Rangking = 2 });

            this.OSs = new List<OsModel>();
            this.OSs.Add(new OsModel { Id = 1, Name = "Android", Rangking = 1 });
            this.OSs.Add(new OsModel{ Id = 2, Name = "IOS", Rangking = 2 });

            this.CamBacks = new List<CameraBackModel>();
            this.CamBacks.Add(new CameraBackModel {Id=0, Name="12 MP", Rangking=1  });
            this.CamBacks.Add(new CameraBackModel { Id = 1, Name = "24 MP", Rangking = 2 });


            this.CamFronts = new List<CameraFrontModel>();
            this.CamFronts.Add(new CameraFrontModel { Id = 0, Name = "16 MP" });
            this.CamFronts.Add(new CameraFrontModel { Id = 0, Name = "24 MP" });

            


            Alternatives = new List<Alternatif>();

            Alternatives.Add(new Alternatif
            {
                Id = 1,
                Code = "A1",
                Name = "Asus Pro"
            });

            Alternatives.Add(new Alternatif
            {
                Id = 2,
                Code = "A2",
                Name = "Asus Vivo"


            });

            Alternatives.Add(new Alternatif
            {
                Id = 3,
                Code = "A3",
                Name = "Aspire"


            });
            Alternatives.Add(new Alternatif
            {
                Id = 4,
                Code = "A4",
                Name = "Hp Pivilon"


            });
            Alternatives.Add(new Alternatif
            {
                Id = 5,
                Code = "A5",
                Name = "Acer z14"


            });

            //Bobot





        }











        public static double[,] Bobots(int c, int a)
        {
            var bobot = new double[c, a];
            bobot[0, 0] = 1;
            bobot[0, 1] = 2;
            bobot[0, 2] = 3;
            bobot[0, 3] = 4;
            bobot[0, 4] = 5;

            bobot[1, 0] = 5;
            bobot[1, 1] = 1;
            bobot[1, 2] = 5;
            bobot[1, 3] = 5;
            bobot[1, 4] = 4;

            bobot[2, 0] = 4;
            bobot[2, 1] = 3;
            bobot[2, 2] = 4;
            bobot[2, 3] = 4;
            bobot[2, 4] = 1;


            bobot[3, 0] = 5;
            bobot[3, 1] = 4;
            bobot[3, 2] = 5;
            bobot[3, 3] = 5;
            bobot[3, 4] = 4;



            bobot[4, 0] = 4;
            bobot[4, 1] = 3;
            bobot[4, 2] = 4;
            bobot[4, 3] = 4;
            bobot[4, 4] = 4;

            return bobot;


        }


    


    }
}