using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using TopsisLIB.Helpers;

namespace TopsisLIB.Models
{
    [TableName("handphones")]
    public class handphone: BaseNotifyProperty
    {
        [PrimaryKey("IdHandphone")]
        [DbColumn("IdHandphone")]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChange("IdHandphone");
            }
        }

        [DbColumn("Name")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChange("Name");
            }
        }

        [DbColumn("ProducentId")]
        public int ProducentId
        {
            get { return _producentid; }
            set
            {
                _producentid = value;
                OnPropertyChange("ProducentId");
            }
        }

        [DbColumn("Memory")]
        public string Storage
        {
            get { return _memory; }
            set
            {
                _memory = value;
                OnPropertyChange("Memory");
            }
        }

        [DbColumn("Os")]
        public string Os
        {
            get { return _os; }
            set
            {
                _os = value;
                OnPropertyChange("Os");
            }
        }

        [DbColumn("Price")]
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChange("Price");
            }
        }

        [DbColumn("CameraFront")]
        public string CameraFront
        {
            get { return _camerafront; }
            set
            {
                _camerafront = value;
                OnPropertyChange("CameraFront");
            }
        }

        [DbColumn("CameraBack")]
        public string CameraBack
        {
            get { return _cameraback; }
            set
            {
                _cameraback = value;
                OnPropertyChange("CameraBack");
            }
        }

        [DbColumn("RAM")]
        public string Memory
        {
            get { return _ram; }
            set
            {
                _ram = value;
                OnPropertyChange("RAM");
            }
        }

        [DbColumn("MemoryExternal")]
        public string StorageExternal
        {
            get { return _memoryexternal; }
            set
            {
                _memoryexternal = value;
                OnPropertyChange("MemoryExternal");
            }
        }

        [DbColumn("LayarSentuh")]
        public YaStatus LayarSentuh
        {
            get { return _layarsentuh; }
            set
            {
                _layarsentuh = value;
                OnPropertyChange("LayarSentuh");
            }
        }

        [DbColumn("MadeIn")]
        public string MadeIn
        {
            get { return _madein; }
            set
            {
                _madein = value;
                OnPropertyChange("MadeIn");
            }
        }


        private int _tahun;
        [DbColumn("Tahun")]
        public int Tahun
        {
            get { return _tahun; }
            set { _tahun = value; OnPropertyChange("Tahun"); }
        }

      


        public string ProducentName { get; set; }
        public double Score { get; set; }

        private int _id;
        private string _name;
        private int _producentid;
        private string _memory;
        private string _os;
        private double _price;
        private string _camerafront;
        private string _cameraback;
        private string _ram;
        private string _memoryexternal;
        private YaStatus _layarsentuh;
        private string _madein;
    }
 
 
}


