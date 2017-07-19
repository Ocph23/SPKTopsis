using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using TopsisLIB;
using TopsisLIB.DataCollections;
using TopsisLIB.Models;

namespace SPKWithTopsis.ViewModels
{
    public class LaptopVM
    {
        public ObservableCollection<computer> Source { get; set; }

        public CollectionView SourceView { get; set; }
        
        private IDataCollection<computer> data = new ComputerCollections();
        private computer _selected;

        public CommandHandler AddPhoto { get; set; }
        public BitmapImage NewImage { get; set; }

        public List<Photo> ListPhoto { get; set; }
        public CollectionView ListPhotoView { get; set; }

        public computer SelectedItem {
            get {
                return _selected;
            } set {

                _selected = value;
              var a = Task.Factory.StartNew(() => GetPhoto(value.Id));
                this.CompleteGetPhoto(a);
            } }

        private async void CompleteGetPhoto(Task<List<Photo>> a)
        {
            this.ListPhoto.Clear();
          

            var res = await a;
            foreach(var item in res)
            {
                ListPhoto.Add(item);
            }

            ListPhotoView.Refresh();

        }

        private List<Photo> GetPhoto(int id)
        {
            var res= new PhotoCollection().GetData(id, PhotoType.Laptop);
            return res;
        }

        public LaptopVM()
        {
            ListPhoto = new List<Photo>();
            ListPhotoView = (CollectionView)CollectionViewSource.GetDefaultView(ListPhoto);
            AddCommand = new CommandHandler { CanExecuteAction = addCommandvalidation, ExecuteAction = addCommandAction };
            EditCommand = new CommandHandler { CanExecuteAction = editCommandValidation, ExecuteAction = editCommandAction };
            DeleteCommand = new CommandHandler { CanExecuteAction = deleteCommandValidation, ExecuteAction = deleteCommandAction };
            Source = new ObservableCollection<computer>(data.GetData());
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(Source);
            AddPhoto = new CommandHandler { CanExecuteAction = x => SelectedItem!=null, ExecuteAction = AddPhotoAction };
        }

        private void AddPhotoAction(object obj)
        {
            var form = new Forms.AddPhotoView(SelectedItem,PhotoType.Laptop);
            form.ShowDialog();

            if(form.Model!=null)
            {
                this.ListPhoto.Add(form.Model);
            }


        }

        //Command Methode
        private void addCommandAction(object obj)
        {

          
            var form = new Forms.AddLaptopView();
            var vm = new ViewModels.AddComputerVM(ChangeStatus.New, Source, SourceView, SelectedItem) {WindowClose=form.Close };
            form.DataContext = vm;
            form.ShowDialog();
        }

        private void editCommandAction(object obj)
        {
            var vm = new ViewModels.AddComputerVM(ChangeStatus.Edit, Source, SourceView, SelectedItem);
            var form = new Forms.AddLaptopView();
            form.DataContext = vm;
            form.ShowDialog();
        }

        private void deleteCommandAction(object obj)
        {
            var data = new TopsisLIB.DataCollections.ComputerCollections();
            var dialig =MessageBox.Show("Yakin Menghapus data ?", "Confirm", MessageBoxButton.YesNo);
            if (dialig == MessageBoxResult.Yes)
            {
                var isDelete = data.Remove(SelectedItem);
                if (isDelete)
                {
                    MessageBox.Show("Data Berhasil Dihapus");
                    Source.Remove(SelectedItem);
                    SourceView.Refresh();
                }
                else
                    MessageBox.Show("Data Gagal Dihapus");
            }
        }




        private bool addCommandvalidation(object obj)
        {
            return true;
        }
        private bool editCommandValidation(object obj)
        {
            return SelectedItem != null ? true : false;
        }

        private bool deleteCommandValidation(object obj)
        {
            return SelectedItem != null ? true : false;
        }

        //Command Defenition

        public CommandHandler AddCommand { get; set; }
        public CommandHandler EditCommand { get; set; }
        public CommandHandler DeleteCommand { get; set; }



    }
}
