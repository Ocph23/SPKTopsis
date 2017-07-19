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
    public class ProducentVM
    {
        public ObservableCollection<producent> Source { get; set; }

        public CollectionView SourceView { get; set; }

        public producent SelectedItem { get; set; }
        TopsisLIB.DataCollections.ProducentCollections dataCollection = new TopsisLIB.DataCollections.ProducentCollections();

        public ProducentVM()
        {
            AddCommand = new CommandHandler { CanExecuteAction = addCommandvalidation, ExecuteAction = addCommandAction };
            EditCommand = new CommandHandler { CanExecuteAction = editCommandValidation, ExecuteAction = editCommandAction };
            DeleteCommand = new CommandHandler { CanExecuteAction = deleteCommandValidation, ExecuteAction = deleteCommandAction };
            Source = new ObservableCollection<producent>(dataCollection.GetData());
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(Source);
        }

        //Command Methode
        private void addCommandAction(object obj)
        {
            var vm = new ViewModels.AddProducentVM(ChangeStatus.New, Source, SourceView, SelectedItem);
            var form = new Forms.AddProducent();
            form.DataContext = vm;
            form.ShowDialog();
        }

        private void editCommandAction(object obj)
        {
            var vm = new ViewModels.AddProducentVM(ChangeStatus.Edit, Source, SourceView, SelectedItem);
            var form = new Forms.AddProducent();
            form.DataContext = vm;
            form.ShowDialog();
        }

        private void deleteCommandAction(object obj)
        {
            var isDeleted = dataCollection.Remove(SelectedItem);
            if (isDeleted)
            {
                this.Source.Remove(SelectedItem);
                this.SourceView.Refresh();
                MessageBox.Show("Data Berhasil Dihapus");
            }
            else
                MessageBox.Show("Data Gagal Dihaspus");
        }


        private bool addCommandvalidation(object obj)
        {
            return true;
        }
        private bool editCommandValidation(object obj)
        {
            return true;
        }

        private bool deleteCommandValidation(object obj)
        {
            return true;
        }

        //Command Defenition

        public CommandHandler AddCommand { get; set; }
        public CommandHandler EditCommand { get; set; }
        public CommandHandler DeleteCommand { get; set; }
    }
}
