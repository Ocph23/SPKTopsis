using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopsisLIB.DataCollections
{
    public interface IDataCollection<T>
    {
        List<T> GetData();
        int Add(T item);
        bool Remove(T item);
        bool Update(T item);

        List<T> GetData(int id, PhotoType type);
    }
}
