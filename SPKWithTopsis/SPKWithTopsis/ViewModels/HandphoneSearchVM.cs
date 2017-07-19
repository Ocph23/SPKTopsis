using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TopsisLIB;
using TopsisLIB.Criterias;
using TopsisLIB.DataCollections;
using TopsisLIB.Models;

namespace SPKWithTopsis.ViewModels
{
    public class HandphoneSearchVM:handphone
    {
        public CollectionView OsView { get; set; }
        public string OsSelected { get; set; }

        public CollectionView StorageView { get; set; }
        public StoregeModel StorageSelected { get; set; }

        public CollectionView CameraFrontView { get; set; }
        public CameraFrontModel CameraFrontSelected { get; set; }

        public CollectionView CameraBackView { get; set; }
        public CameraBackModel CameraBackSelected { get; set; }

        public CollectionView MemoryView { get; set; }
        public RamModel MemorySelected { get; set; }

        public CollectionView ProducentView { get; set; }
        public producent ProducentSelected { get; set; }
        public CommandHandler SearchCommand { get; private set; }

        private PhoneDataLayer dal = new PhoneDataLayer();
        IDataCollection<handphone> handphoneCollection = new HandphoneCollection();
        private List<handphone> Datas { get; set; }

        private CollectionView collection { get; set; }

        public List<Photo> ListPhoto { get; set; }
        public CollectionView ListPhotoView { get; set; }

        IDataCollection<producent> pr = new ProducentCollections();
        private handphone _selected;

        public HandphoneSearchVM()
        {
            ListPhoto = new List<Photo>();
            ListPhotoView = (CollectionView)CollectionViewSource.GetDefaultView(ListPhoto);


            StorageView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Storages);
            MemoryView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Rams);
            CameraBackView = (CollectionView)CollectionViewSource.GetDefaultView(dal.CamBacks);
            CameraFrontView = (CollectionView)CollectionViewSource.GetDefaultView(dal.CamFronts);
            OsView = (CollectionView)CollectionViewSource.GetDefaultView(dal.OSs);



            ProducentView = (CollectionView)CollectionViewSource.GetDefaultView(pr.GetData());

            Source = new ObservableCollection<handphone>();
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(this.Source);
            SearchCommand = new CommandHandler { CanExecuteAction = SearchValiation, ExecuteAction=x=> SearchAction() };
            Alternatives = new List<AlternativeHandPhone>();
            Datas = handphoneCollection.GetData();

            collection  = (CollectionView)CollectionViewSource.GetDefaultView(Datas);
            collection.Filter = colFilter;
        }



        public handphone SelectedItem
        {
            get
            {
                return _selected;
            }
            set
            {

                _selected = value;
                var a = Task.Factory.StartNew(() => GetPhoto(value.Id));
                this.CompleteGetPhoto(a);
                OnPropertyChange("SelectedItem");
            }
        }


        private async void CompleteGetPhoto(Task<List<Photo>> a)
        {
            this.ListPhoto.Clear();


            var res = await a;
            foreach (var item in res)
            {
                ListPhoto.Add(item);
            }

            ListPhotoView.Refresh();

        }

        private List<Photo> GetPhoto(int id)
        {
            var res = new PhotoCollection().GetData(id, PhotoType.Handphone);
            return res;
        }


        private bool colFilter(object O)
        {
            var c = O as handphone;
            if (this.ProducentId == 0)
            {
                return c.CameraBack.Equals(this.CameraBack) || c.CameraFront.Equals(this.CameraFront) || c.Memory.Equals(this.Memory) ||
                     c.Price.Equals(this.Price) || c.Os.Equals(this.Os) || c.Storage.Equals(this.Storage);
            }
            else
            {
                return c.ProducentId.Equals(this.ProducentId) && (c.CameraBack.Equals(this.CameraBack) || c.CameraFront.Equals(this.CameraFront) || c.Memory.Equals(this.Memory) ||
                     c.Price.Equals(this.Price) || c.Os.Equals(this.Os) || c.Storage.Equals(this.Storage));
            }

          
        }

        private void SearchAction()
        {
            Source.Clear();
            this.Alternatives = new List<AlternativeHandPhone>();
            collection.Refresh();
            int id = 1;

            foreach (handphone item in collection)
            {
                var ios = dal.IOSs.Where(O => O.Name == "Tidak").FirstOrDefault().Rangking;
                var android = dal.Androids.Where(O => O.Name == "Tidak").FirstOrDefault().Rangking;


                if (this.Os != string.Empty)
                {
                    if (this.Os == "IOS" && item.Os == "IOS")
                    {
                        ios = dal.IOSs.Where(O => O.Name == "Ya").FirstOrDefault().Rangking;
                    }

                    if (this.Os == "Android" && item.Os == "Android")
                    {
                        android = dal.Androids.Where(O => O.Name == "Ya").FirstOrDefault().Rangking;
                    }

                }



                var front = dal.CamFronts.Where(O => O.Name == item.CameraFront).FirstOrDefault().Rangking;
                var back = dal.CamBacks.Where(O => O.Name == item.CameraBack).FirstOrDefault().Rangking;

                var ram = dal.Rams.Where(O => O.Name == item.Memory).FirstOrDefault().Rangking;
                var pric = dal.Prices.Where(O => O.StartPrice <= item.Price && O.EndPrice > item.Price).FirstOrDefault().Rangking;
                var storage = dal.Storages.Where(O => O.Name == item.Storage).FirstOrDefault().Rangking;



                var alternatif = new AlternativeHandPhone { Harga = pric, Ram = ram, Android = android, IOS = ios, CamBack = back, CamFront = front, Storage = storage, Name = item.Name, Id = item.Id, Code = "A" + id };

                this.Alternatives.Add(alternatif);
                id++;

            }


            if (this.Alternatives.Count > 0)
            {

                var dataProccess = new DataProccessPhoneModel(dal.Criterias, this.Alternatives);
                Source.Clear();
                foreach (var item in this.Alternatives.OrderByDescending(O => O.Value))
                {
                    var i = Datas.Where(O => O.Id == item.Id).FirstOrDefault();
                    i.Score = item.Value;

                    Source.Add(i);

                }

                SourceView.Refresh();
            }
            else
                MessageBox.Show("Data Tidak Ditemukan");

        }

        private bool SearchValiation(object obj)
        {
            if (this.StorageSelected!=null||this.CameraBackSelected != null ||this.CameraFrontSelected!= null ||MemorySelected!= null || this.OsSelected != null || this.Price > 0 )
                return true;
            else
                return false;
        }


        //Search

        public CollectionView SourceView { get; private set; }
        public ObservableCollection<handphone> Source { get; set; }
        public List<AlternativeHandPhone> Alternatives { get; set; }
    }
}
