using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TopsisLIB.Models;
using TopsisLIB.Criterias;
using TopsisLIB;
using TopsisLIB.DataCollections;
using System.Windows;

namespace SPKWithTopsis.ViewModels
{
    public class AddComputerVM : TopsisLIB.Models.computer
    {
        private computer selectedItem;
        private ObservableCollection<computer> source;
        private CollectionView sourceView;
        private ChangeStatus status;

      

        public CollectionView HardisksView { get; set; }
        public HardiskModel HardiskSelected { get; set; }


        public CollectionView RamsView { get; set; }
        public RamModel RamSelected { get; set; }

        public CollectionView ProccesorsView { get; set; }
        public ProccesorModel ProccesorSelected { get; set; }

        public CollectionView LcdsView{ get; set; }
        public LcdModel LcdSelected { get; set; }

        public CollectionView ProducentView { get; set; }
        public producent ProducentSelected { get; set; }

        public CollectionView Tahuns { get; set; }


        public AddComputerVM(ChangeStatus status, ObservableCollection<computer> source, CollectionView sourceView, computer selectedItem)
        {
            var dal = new DataLayer();

            var date = DateTime.Now.Year;
            List<int> list = new List<int>();
            for(var i =date;i>date-10;i--)
            {
                list.Add(i);
            }

            Tahuns = (CollectionView)CollectionViewSource.GetDefaultView(list);



            this.HardisksView= (CollectionView)CollectionViewSource.GetDefaultView(dal.Hardisks);
            this.RamsView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Rams);
            this.ProccesorsView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Proccessors);
            this.LcdsView = (CollectionView)CollectionViewSource.GetDefaultView(dal.Lcds);

            IDataCollection<producent> pr = new ProducentCollections();
            this.ProducentView = (CollectionView)CollectionViewSource.GetDefaultView(pr.GetData());
            this.source = source;
            this.sourceView = sourceView;
            this.selectedItem = selectedItem;
            this.status = status;

            SaveCommand = new CommandHandler { CanExecuteAction = SaveValidation, ExecuteAction = SaveAction };

            if(status== ChangeStatus.Edit)
            {
                this.Hardisk = selectedItem.Hardisk;
                this.Id = selectedItem.Id;
                this.LCD = selectedItem.LCD;
                this.Memory = selectedItem.Memory;
                this.Name = selectedItem.Name;
                this.Price = selectedItem.Price;
                this.Proccesor = selectedItem.Proccesor;
                this.ProducentId = selectedItem.ProducentId;
                this.ProducentName = this.ProducentName;
                this.Series = this.Series;
                
            }


        }

        private bool SaveValidation(object obj)
        {
            if (this.HardiskSelected != null && LcdSelected != null && RamSelected != null && ProccesorSelected != null)
                return true;
            else
                return false;
        }

        private void SaveAction(object obj)
        {
           if(this.status== ChangeStatus.New)
            {
                var item = this;
                item.ProducentName = ProducentSelected.Name;
                var coll = new ComputerCollections();
                var res=coll.Add(item);
                if(res>0)
                {
                    item.Id = res;
                    MessageBox.Show("Data Berhasil Disimpan");
                    this.source.Add(item);
                    this.sourceView.Refresh();
                    this.selectedItem = item;
                    WindowClose();
                }
                else
                {
                    MessageBox.Show("Data Gagal Disimpan");
                }

            }else if(this.status== ChangeStatus.Edit)
            {
                var item = this;
                item.ProducentName = ProducentSelected.Name;
                var coll = new ComputerCollections();
                var isUpdated = coll.Update(item);
                if (isUpdated)
                {
                    MessageBox.Show("Data Berhasil Disimpan");
                    this.sourceView.Refresh();
                    this.selectedItem = item;
                  
                }
                else
                {
                    MessageBox.Show("Data Gagal Disimpan");
                }
            }

        }

        //Comand defenition


        public CommandHandler SaveCommand { get; set; }
        public Action WindowClose { get; internal set; }
    }
}
