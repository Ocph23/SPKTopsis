using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Models;

namespace TopsisLIB.DataCollections
{
    public class ProducentCollections:IDataCollection<producent>
    {
      
             public List<producent> GetData()
        {
            using (var db = new OcphDbContext())
            {
                return db.Producents.Select().ToList();
            }
        }
      

        public int Add(producent item)
        {
            using (var db = new OcphDbContext())
            {
                var id = db.Producents.InsertAndGetLastID(item);
                return id;
              
            }
        }

     
        public bool Remove(producent item)
        {
            using (var db = new OcphDbContext())
            {
                return  db.Producents.Delete(O => O.Id == item.Id);

            }
        }

        public bool Update(producent item)
        {
            using (var db = new OcphDbContext())
            {
                return db.Producents.Update(O => new { O.Name, O.Description }, item, O => O.Id == item.Id);
            }
        }

        public List<producent> GetData(int id)
        {
            throw new NotImplementedException();
        }

        public List<producent> GetData(int id, PhotoType type)
        {
            throw new NotImplementedException();
        }
    }
}
