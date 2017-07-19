using DAL.DContext;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Models;


namespace TopsisLIB
{
    public class OcphDbContext : IDbContext, IDisposable
    {
        private string connectionString = "Server=localhost;database=dbstopsis;UID=root;password=;CharSet=utf8;Persist Security Info=True";
      // private string connectionString = "Server=localhost;database=trireksapenjualan;UID=root;password=;CharSet=utf8;Persist Security Info=True";

        private IDbConnection _Connection = null;

        public OcphDbContext()
        {

        }

        // Database Repository

        public IRepository<computer> Laptops { get { return new Repository<computer>(this); } }
        public IRepository<handphone> Handphones { get { return new Repository<handphone>(this); } }
        public IRepository<producent> Producents { get { return new Repository<producent>(this); } }
        public IRepository<Photo> Photos { get { return new Repository<Photo>(this); } }
        public IRepository<User> Users { get { return new Repository<User>(this); } }

        public IDbConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new MySqlDbContext(this.connectionString);
                    return _Connection;
                }
                else
                {
                    return _Connection;
                }
            }
        }

     

        public void Dispose()
        {
            if (_Connection != null)
            {
                if (this.Connection.State != ConnectionState.Closed)
                {
                    this.Connection.Close();
                }
            }
        }

    }
}
