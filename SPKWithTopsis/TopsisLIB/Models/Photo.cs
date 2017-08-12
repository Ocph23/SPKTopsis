using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopsisLIB.Helpers;

namespace TopsisLIB.Models
{

    [TableName("photos")]
    public class Photo: BaseNotifyProperty
    {
        [PrimaryKey("IdPhoto")]
        [DbColumn("IdPhoto")]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChange("IdPhoto");
            }
        }

        [DbColumn("ProductType")]
        public PhotoType ProductType
        {
            get { return _producttype; }
            set
            {
                _producttype = value;
                OnPropertyChange("ProductType");
            }
        }

        [DbColumn("ProductId")]
        public int ProductId
        {
            get { return _productid; }
            set
            {
                _productid = value;
                OnPropertyChange("ProductId");
            }
        }

        [DbColumn("photo")]
        public byte[] photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                OnPropertyChange("photo");
            }
        }

        private int _id;
        private PhotoType _producttype;
        private int _productid;
        private byte[] _photo;
    }
}
