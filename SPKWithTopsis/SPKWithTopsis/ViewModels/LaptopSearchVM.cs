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
    public class LaptopSearchVM:computer
    {



        public CollectionView HardisksView { get; set; }
        public HardiskModel HardiskSelected { get; set; }

        public CollectionView RamsView { get; set; }
        public RamModel RamSelected { get; set; }

        public CollectionView ProccesorsView { get; set; }
        public ProccesorModel ProccesorSelected { get; set; }

        public CollectionView LcdsView { get; set; }
        public LcdModel LcdSelected { get; set; }

        public CollectionView ProducentView { get; set; }
        public producent ProducentSelected { get; set; }
        public Visibility ViewDetails { get { return _viewdetails; } set {
                _viewdetails = value;
                OnPropertyChange("ViewDetails");
            } }

        private DataLayer  dal = new DataLayer();
        private computer _selected;
        private Visibility _viewdetails;

        public LaptopSearchVM()
        {
            ViewDetails = Visibility.Hidden;
            ListPhoto = new List<Photo>();
            ListPhotoView = (CollectionView)CollectionViewSource.GetDefaultView(ListPhoto);

            this.HardisksView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Hardisks);
            this.RamsView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Rams);
            this.ProccesorsView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Proccessors);
            this.LcdsView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Lcds);

            IDataCollection<producent> pr = new ProducentCollections();
            this.ProducentView = (CollectionView)CollectionViewSource.GetDefaultView(pr.GetData());

            SearchCommand = new CommandHandler { CanExecuteAction = SearchValiation, ExecuteAction = SearchAction };



            //data
            this.Source = new ObservableCollection<computer>();
            this.SourceView = (CollectionView)CollectionViewSource.GetDefaultView(this.Source);
            Alternatives = new List<Alternatif>();
            AlternativeSourceView = (CollectionView)CollectionViewSource.GetDefaultView(this.Alternatives);
            this.Clear();
        }

        private void SearchAction(object obj)
        {
           if(this.SelectedItem!=null)
            {
                this.SelectedItem = null;
            }
            this.Source.Clear();
            Alternatives.Clear();
            IDataCollection<computer> pr = new  ComputerCollections();

            var datas = pr.GetData();

           ICollectionView collection = (CollectionView)CollectionViewSource.GetDefaultView(datas);
            IEqualityComparer<string> compare = StringComparer.InvariantCultureIgnoreCase;
            collection.Filter = O =>
            {
                var c = O as computer;
                if(this.ProducentId==0)
                {
                    return c.Hardisk.Equals(this.Hardisk) || c.LCD.Equals(this.LCD) || c.Memory.Equals(this.Memory) || c.Price.Equals(this.Price) || c.Proccesor.Equals(this.Proccesor);
                }else
                {
                    return c.ProducentId.Equals(this.ProducentId) && (c.Hardisk.Equals(this.Hardisk) || c.LCD.Equals(this.LCD) || c.Memory.Equals(this.Memory) || c.Price.Equals(this.Price) || c.Proccesor.Equals(this.Proccesor));
                }

               
            };

            collection.Refresh();
            int id = 1;
            Alternatives.Clear();
            foreach(var item in collection)
            {
                
                var i = item as computer;
                var ha = dal.Hardisks.Where(O => O.Name == i.Hardisk).FirstOrDefault().Rangking;
                var proc = dal.Proccessors.Where(O => O.Name == i.Proccesor).FirstOrDefault().Rangking;
                var ram = dal.Rams.Where(O => O.Name == i.Memory).FirstOrDefault().Rangking;
                var pric = dal.Prices.Where(O => O.StartPrice<=i.Price && O.EndPrice>i.Price).FirstOrDefault().Rangking;
                var lc = dal.Lcds.Where(O => O.Name == i.LCD).FirstOrDefault().Rangking;
                var alternatif = new Alternatif { Hardisk=ha, Harga=pric, LCD=lc, ProccesorCode=proc, RAMCode=ram, Name=i.Name, Id=i.Id, Code="A"+id };

                this.Alternatives.Add(alternatif);
                id++;
            }


            var dataProccess = new DataProccessModel(dal.Criterias, this.Alternatives);
            Source.Clear();
            foreach(var item in this.Alternatives.OrderByDescending(O=>O.Value))
            {
                var i = datas.Where(O => O.Id == item.Id).FirstOrDefault();
                i.Score = item.Value;

                Source.Add(i);
               
            }

            SourceView.Refresh();
            AlternativeSourceView.Refresh();

        }

        private bool SearchValiation(object obj)
        {
            if (this.HardiskSelected != null || LcdSelected != null || RamSelected != null || ProccesorSelected != null || this.Price > 0)
                return true;
            else
                return false;
        }

        public void Clear()
        {
            this.Hardisk = string.Empty;
            this.Id = 0;
            this.LCD = string.Empty;
            this.Memory = string.Empty;
            this.Price = 0;
            this.ProducentId = 0;
            this.Proccesor = string.Empty;
            
        }



        //Search

      
        public computer SelectedItem
        {
            get
            {
                return _selected;
            }
            set
            {

                _selected = value;
                if(value!=null)
                {
                    ViewDetails = Visibility.Visible;
                    var a = Task.Factory.StartNew(() => GetPhoto(value.Id));
                    this.CompleteGetPhoto(a);
                }else
                {
                    ViewDetails = Visibility.Hidden;
                }
              
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
            var res = new PhotoCollection().GetData(id, PhotoType.Laptop);
            return res;
        }


        public CommandHandler SearchCommand { get; set; }
        public CollectionView SourceView { get; private set; }
        public CollectionView AlternativeSourceView { get; private set; }
        public ObservableCollection<computer> Source { get; private set; }
        public List<Alternatif> Alternatives { get;  set; }
        public List<Photo> ListPhoto { get; private set; }
        public CollectionView ListPhotoView { get; private set; }
    }
}
