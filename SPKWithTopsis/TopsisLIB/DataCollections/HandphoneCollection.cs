using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Models;

namespace TopsisLIB.DataCollections
{
    public class HandphoneCollection : IDataCollection<handphone>
    {
        public int Add(handphone item)
        {
           using(var db = new OcphDbContext())
            {
                return db.Handphones.InsertAndGetLastID(item);
            }
        }

        public List<handphone> GetData()
        {
            using (var db = new OcphDbContext())
            {
                var result = from lap in db.Handphones.Select()
                             join pro in db.Producents.Select() on lap.ProducentId equals pro.Id
                             select new handphone
                             {
                                 CameraBack = lap.CameraBack,
                                 CameraFront = lap.CameraFront,
                                 Os = lap.Os,
                                 Storage = lap.Storage,
                                 Id = lap.Id,
                                 Memory = lap.Memory,
                                 Name = lap.Name,
                                 Price = lap.Price,
                                 LayarSentuh = lap.LayarSentuh,
                                 MadeIn = lap.MadeIn,
                                 StorageExternal = lap.StorageExternal,
                                 ProducentId = lap.ProducentId,
                                 ProducentName = pro.Name,
                                 Score = 0, Tahun=lap.Tahun
                             };

                return result.ToList();
            }
        }

        public List<handphone> GetData(int id)
        {
            throw new NotImplementedException();
        }

        public List<handphone> GetData(int id, PhotoType type)
        {
            throw new NotImplementedException();
        }

        public bool Remove(handphone item)
        {
            using(var db = new OcphDbContext())
            {
                return db.Handphones.Delete(O => O.Id == item.Id);
            }
        }

        public bool Update(handphone item)
        {
            using(var db = new OcphDbContext())
            {
                return db.Handphones.Update(O => new {O.LayarSentuh,O.MadeIn,O.StorageExternal, O.CameraBack, O.CameraFront, O.Memory, O.Name, O.Os, O.Price, O.Storage, O.ProducentId }, item, O => O.Id == item.Id);
            }
        }
    }
}
