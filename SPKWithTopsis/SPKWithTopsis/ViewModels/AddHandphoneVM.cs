using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class AddHandphoneVM:handphone
    {
        private handphone selectedItem;
        private ObservableCollection<handphone> source;
        private CollectionView sourceView;
        private ChangeStatus status;

        public CollectionView OsView { get; set; }
        public string OsSelected { get; set; }

        public CollectionView StoregeView { get; set; }
        public StoregeModel StoreageSelected { get; set; }
        public CollectionView StoregeExternalView { get; set; }
        public StoregeModel StoreageExternalSelected { get; set; }

        public CollectionView CameraFrontView { get; set; }
        public CameraFrontModel CameraFrontSelected { get; set; }

        public CollectionView CameraBackView { get; set; }
        public CameraBackModel CameraBackSelected { get; set; }

        public CollectionView MemoryView { get; set; }
        public RamModel MemorySelected { get; set; }

        public CollectionView ProducentView { get; set; }
        public producent ProducentSelected { get; set; }
        public CommandHandler SaveCommand { get; private set; }
        public Action WindowClose { get;  set; }
        public CommandHandler DeleteCommand { get; private set; }

        public CollectionView Tahuns { get; set; }


        private PhoneDataLayer dal = new PhoneDataLayer();
        IDataCollection<handphone> handphoneCollection = new HandphoneCollection();

        public AddHandphoneVM(ChangeStatus status, ObservableCollection<handphone> source, CollectionView sourceView, handphone selectedItem)
        {
            var date = DateTime.Now.Year;
            List<int> list = new List<int>();
            for (var i = date; i > date - 10; i--)
            {
                list.Add(i);
            }

            Tahuns = (CollectionView)CollectionViewSource.GetDefaultView(list);


            this.status = status;
            this.source = source;
            this.sourceView = sourceView;
            this.selectedItem = selectedItem;

         
            this.StoregeView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Storages);
            this.StoregeExternalView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Storages);
            this.MemoryView= (CollectionView)CollectionViewSource.GetDefaultView(dal.Rams);
            this.CameraBackView= (CollectionView)CollectionViewSource.GetDefaultView(dal.CamBacks);
            this.CameraFrontView = (CollectionView)CollectionViewSource.GetDefaultView(dal.CamFronts);
            this.OsView= (CollectionView)CollectionViewSource.GetDefaultView(dal.OSs);


            IDataCollection<producent> pr = new ProducentCollections();
            this.ProducentView = (CollectionView)CollectionViewSource.GetDefaultView(pr.GetData());

            SaveCommand = new CommandHandler { CanExecuteAction = SaveValidation, ExecuteAction = SaveAction };
         

            if (status == ChangeStatus.Edit)
            {
                this.Id = selectedItem.Id;
                this.Memory = selectedItem.Memory;
                this.Name = selectedItem.Name;
                this.Price = selectedItem.Price;
                this.ProducentId = selectedItem.ProducentId;
                this.CameraBack = selectedItem.CameraBack;
                this.CameraFront = selectedItem.CameraFront;
                this.Os = selectedItem.Os;
                this.ProducentId = selectedItem.ProducentId;
                this.ProducentName = selectedItem.ProducentName;
                this.Storage = selectedItem.Storage;
                

            }

        }
    
        private void SaveAction(object obj)
        {
            var item = this;

            if (status == ChangeStatus.New)
            {
                var id = handphoneCollection.Add(item);
                if (id > 0)
                {
                    item.Id = id;
                    MessageBox.Show("Data Berhasil Disimpan");
                    item.ProducentName = ProducentSelected.Name;


                    this.source.Add(item);
                    this.sourceView.Refresh();
                    this.WindowClose();

                }
                else
                {
                    MessageBox.Show("Data Gagal Disimpan");
                }
            }else
            {
                var isUpdated = handphoneCollection.Update(item);
                if (isUpdated)
                {
                    MessageBox.Show("Data Berhasil Disimpan");
                    item.ProducentName = ProducentSelected.Name;
                    this.sourceView.Refresh();
                    this.WindowClose();

                }
                else
                {
                    MessageBox.Show("Data Gagal Disimpan");
                }
            }

        }

        private bool SaveValidation(object obj)
        {
            if (this.ProducentSelected != null)
            {
                return true;
            } else
                return false;
        }
    }
}
