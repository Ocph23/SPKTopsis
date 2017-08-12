using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using TopsisLIB.Helpers;

namespace TopsisLIB.Models 
{ 
   
    [TableName("computers")]
    public class computer: BaseNotifyProperty
    {
        [PrimaryKey("IdComputer")]
        [DbColumn("IdComputer")]
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChange("IdComputer");
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

        [DbColumn("Series")]
        public string Series
        {
            get { return _series; }
            set
            {
                _series = value;
                OnPropertyChange("Series");
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
        public string Memory
        {
            get { return _memory; }
            set
            {
                _memory = value;
                OnPropertyChange("Memory");
            }
        }

        [DbColumn("Proccesor")]
        public string Proccesor
        {
            get { return _proccesor; }
            set
            {
                _proccesor = value;
                OnPropertyChange("Proccesor");
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

        [DbColumn("LCD")]
        public string LCD
        {
            get { return _lcd; }
            set
            {
                _lcd = value;
                OnPropertyChange("LCD");
            }
        }

        [DbColumn("Hardisk")]
        public string Hardisk
        {
            get { return _hardisk; }
            set
            {
                _hardisk = value;
                OnPropertyChange("Hardisk");
            }
        }

        [DbColumn("Kamera")]
        public AdaStatus Kamera
        {
            get { return _kamera; }
            set
            {
                _kamera = value;
                OnPropertyChange("Kamera");
            }
        }

        [DbColumn("Wifi")]
        public AdaStatus Wifi
        {
            get { return _wifi; }
            set
            {
                _wifi = value;
                OnPropertyChange("Wifi");
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

        [DbColumn("Tahun")]
        public int Tahun
        {
            get { return _tahun; }
            set
            {
                _tahun = value;
                OnPropertyChange("Tahun");
            }
        }

        [DbColumn("VGA")]
        public string VGA
        {
            get { return _vga; }
            set
            {
                _vga = value;
                OnPropertyChange("VGA");
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

        public string ProducentName { get; set; }
        public double Score { get; set; }

        private int _id;
        private string _name;
        private string _series;
        private int _producentid;
        private string _memory;
        private string _proccesor;
        private double _price;
        private string _lcd;
        private string _hardisk;
        private AdaStatus _kamera;
        private AdaStatus _wifi;
        private YaStatus _layarsentuh;
        private int _tahun;
        private string _vga;
        private string _madein;
    }

}


