using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Models;

namespace TopsisLIB.DataCollections
{
    public class ComputerCollections : IDataCollection<computer>
    {
        public int Add(computer item)
        {
            using (var db = new OcphDbContext())
            {
                return db.Laptops.InsertAndGetLastID(item);
            }
        }

        public List<computer> GetData()
        {
            using (var db = new OcphDbContext())
            {
                var result= from lap in db.Laptops.Select()
                       join pro in db.Producents.Select() on lap.ProducentId equals pro.Id
                       select new computer
                       {
                           Hardisk = lap.Hardisk,
                           Id = lap.Id,
                           LCD = lap.LCD,
                           Memory = lap.Memory,
                           Name = lap.Name,
                           Price = lap.Price,
                           Proccesor = lap.Proccesor,
                           ProducentId = lap.ProducentId,
                           Kamera = lap.Kamera,
                           LayarSentuh = lap.LayarSentuh,
                           MadeIn = lap.MadeIn,
                           Tahun = lap.Tahun,
                           VGA = lap.VGA,
                           Wifi = lap.Wifi,
                           Series = lap.Series,
                           ProducentName = pro.Name
                       };

                return result.ToList();
            }
        }

        public List<computer> GetData(int id)
        {
            throw new NotImplementedException();
        }

        public List<computer> GetData(int id, PhotoType type)
        {
            throw new NotImplementedException();
        }

        public bool Remove(computer item)
        {
            using (var db = new OcphDbContext())
            {
                return db.Laptops.Delete(o=>o.Id==item.Id);
            }
        }

        public bool Update(computer item) 
        {
            using (var db = new OcphDbContext())
            {
                return db.Laptops.Update(o => new { o.Hardisk, o.LCD, o.Memory, o.Name, o.Price,
                    o.Proccesor, o.ProducentId, o.Series, o.Kamera,o.LayarSentuh,o.MadeIn,o.Tahun,o.VGA}, item,
                    o => o.Id == item.Id);
            }
        }
    }
}
