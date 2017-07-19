using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Models;

namespace TopsisLIB.DataCollections
{
    public class PhotoCollection : IDataCollection<Photo>
    {
        public int Add(Photo item)
        {
            using (var db = new OcphDbContext())
            {
                return db.Photos.InsertAndGetLastID(item);
            }
        }

        public List<Photo> GetData()
        {
            throw new NotImplementedException();
        }

        public List<Photo> GetData(int id, PhotoType type)
        {
            using (var db = new OcphDbContext())
            {
                var Id = id;
                var lap = type;
                var res= db.Photos.Where(O => O.ProductId == Id && O.ProductType== lap).ToList();
                return res;
            }
        }

        public bool Remove(Photo item)
        {
            using (var db = new OcphDbContext())
            {
                return db.Photos.Delete(O=>O.Id==item.Id);
            }
        }

        public bool Update(Photo item)
        {
            using (var db = new OcphDbContext())
            {
                return db.Photos.Update(O => new { O.photo, O.ProductId, O.ProductType }, item, O => O.Id == item.Id);
            }
        }



    }
}
