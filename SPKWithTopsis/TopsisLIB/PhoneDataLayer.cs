using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Criterias;
using TopsisLIB.Models;

namespace TopsisLIB
{
    public class PhoneDataLayer
    {
        public List<Criteria> Criterias { get; set; }
        public List<Criterias.PriceModel> Prices { get; set; }
        public List<Criterias.StoregeModel> Storages { get; set; }
        public List<Criterias.RamModel> Rams { get; set; }
        public List<Criterias.CameraBackModel> CamBacks { get; set; }
        public List<Criterias.CameraFrontModel> CamFronts { get; set; }
        public List<Criterias.OsModel> IOSs { get; set; }
        public List<Criterias.OsModel> Androids { get; set; }

        public List<string> OSs { get; set; }

        public PhoneDataLayer()
        {

            Prices = new List<PriceModel>();
            Storages = new List<StoregeModel>();
            Rams = new List<RamModel>();
            //Handphone 
            OSs = new List<string>();
            OSs.Add("IOS");
            OSs.Add("Android");

            Prices.Add(new PriceModel { Id = 1, Name = "> 14 Juta", StartPrice = 14000000, EndPrice = 100000000, Rangking = 1 });
            Prices.Add(new PriceModel { Id = 2, Name = "11-13 Juta", StartPrice = 11000000, EndPrice = 14000000, Rangking = 2 });
            Prices.Add(new PriceModel { Id = 3, Name = "6-10 Juta", StartPrice = 6000000, EndPrice = 11000000, Rangking = 3 });
            Prices.Add(new PriceModel { Id = 4, Name = "5-6 Juta", StartPrice = 3000000, EndPrice = 6000000, Rangking = 4 });
            Prices.Add(new PriceModel { Id = 5, Name = "< 3 Juta", StartPrice = 0, EndPrice = 3000000, Rangking = 5 });

            Storages.Add(new StoregeModel { Id = 1, Name = "< 8 GB", Value = 8, Rangking = 1 });
            Storages.Add(new StoregeModel { Id = 2, Name = "16 GB", Value = 16, Rangking = 2 });
            Storages.Add(new StoregeModel { Id = 3, Name = "32 GB", Value = 32, Rangking = 3 });
            Storages.Add(new StoregeModel { Id = 4, Name = "64 GB", Value = 64, Rangking = 4 });
            Storages.Add(new StoregeModel { Id = 5, Name = "128 GB", Value = 128, Rangking = 5 });

            Rams.Add(new RamModel { Id = 1, Name = "1 GB", Value = 1, Rangking = 3 });
            Rams.Add(new RamModel { Id = 2, Name = "1.5 GB", Value = 2, Rangking = 4});
            Rams.Add(new RamModel { Id = 2, Name = "2 GB", Value = 2, Rangking = 5 });

         

            Criterias = new List<Criteria>();
            Criterias.Add(new Criteria { Id = 1, Code = "C1", Name = "Harga", Bobot = 5 });
            Criterias.Add(new Criteria { Id = 2, Code = "C2", Name = "Storage", Bobot = 3 });
            Criterias.Add(new Criteria { Id = 3, Code = "C3", Name = "Ram", Bobot = 4 });
            Criterias.Add(new Criteria { Id = 4, Code = "C4", Name = "Camera Front", Bobot = 4 });
            Criterias.Add(new Criteria { Id = 5, Code = "C5", Name = "Camera Back", Bobot = 2 });
            Criterias.Add(new Criteria { Id = 6, Code = "C6", Name = "IOS", Bobot = 2 });
            Criterias.Add(new Criteria { Id = 7, Code = "C7", Name = "Android", Bobot = 2 });



            //Handphone Data

            this.Storages = new List<StoregeModel>();

            this.Storages.Add(new StoregeModel { Id = 1, Name = "2 GB", Rangking = 1 });
            this.Storages.Add(new StoregeModel { Id = 2, Name = "4 GB", Rangking = 2 });

            this.IOSs = new List<OsModel>();
            this.IOSs.Add(new OsModel { Id = 1, Name = "Ya", Rangking = 5 });
            this.IOSs.Add(new OsModel{ Id = 2, Name = "Tidak", Rangking = 3 });

            this.Androids = new List<OsModel>();
            this.Androids.Add(new OsModel { Id = 1, Name = "Ya", Rangking = 5 });
            this.Androids.Add(new OsModel { Id = 2, Name = "Tidak", Rangking = 3 });

            this.CamBacks = new List<CameraBackModel>();
            this.CamBacks.Add(new CameraBackModel {Id=0, Name="1-6 MP", Start=1, End=6, Rangking=3  });
            this.CamBacks.Add(new CameraBackModel { Id = 1, Name = "8-13 MP", Start=8, End=13, Rangking = 5 });

            this.CamFronts= new List<CameraFrontModel>();
            this.CamFronts.Add(new CameraFrontModel { Id = 0, Name = "1-6 MP", Start = 1, End = 6, Rangking = 3 });
            this.CamFronts.Add(new CameraFrontModel { Id = 1, Name = "8-13 MP", Start = 8, End = 13, Rangking = 5 });

        }






    }
}