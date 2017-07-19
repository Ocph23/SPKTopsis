using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TopsisLIB;
using TopsisLIB.Models;

namespace SPKWithTopsis.ViewModels
{
    public class AddProducentVM:TopsisLIB.Models.producent
    {
        private ObservableCollection<producent> source;
        private CollectionView sourceView;
        private producent selectedItem;
        private ChangeStatus status;

        public AddProducentVM(ChangeStatus status, ObservableCollection<producent> source, CollectionView sourceView, producent selectedItem)
        {
            this.status = status;
            this.source = source;
            this.sourceView = sourceView;
            this.selectedItem = selectedItem;
            SaveCommand = new CommandHandler { CanExecuteAction = saveValidation, ExecuteAction = saveAction };

            if (status == ChangeStatus.New)
            {
                this.Kosongkan();
            }else
            {
                this.Id = selectedItem.Id;
                this.Description = selectedItem.Description;
                this.Name = selectedItem.Name;
            }
        }

        private void saveAction(object obj)
        {
            TopsisLIB.DataCollections.ProducentCollections dataCollection = 
                new TopsisLIB.DataCollections.ProducentCollections();

           if(this.status== ChangeStatus.New)
            {
                TopsisLIB.Models.producent item  = this;
                var id = dataCollection.Add(item);
                item.Id = id;
                if(item.Id>0)
                {
                    source.Add(item);
                    sourceView.Refresh();
                    selectedItem = item;
                    MessageBox.Show("Data Berhasil Disimpan");
                }else
                    MessageBox.Show("Data Gagal Disimpan");

            }else
            {
                TopsisLIB.Models.producent item = this;
                var isUpdated = dataCollection.Update(item);
                if (isUpdated)
                {
                    var result =source.Where(O => O.Id == item.Id).FirstOrDefault();
                    result.Name = item.Name;
                    result.Description = item.Description;
                    sourceView.Refresh();
                    MessageBox.Show("Data Berhasil Disimpan");
                }
                else
                    MessageBox.Show("Data Gagal Disimpan");
            }
        }

        private bool saveValidation(object obj)
        {
            if (Name != string.Empty && Description != string.Empty)
            {
                return true;
            }
            else
                return false;
        }

        private void Kosongkan()
        {
            this.Description = string.Empty;
            this.Id = 0;
            this.Name = string.Empty;
        }



        // command 

        public CommandHandler SaveCommand { get; set; }
    }
}
