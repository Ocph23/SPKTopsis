using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TopsisLIB;
using TopsisLIB.DataCollections;
using TopsisLIB.Models;

namespace SPKWithTopsis.ViewModels
{
    public class HandphoneVM
    {
        public CollectionView SourceView { get; set; }
        public CommandHandler AddCommand { get; private set; }
        public CommandHandler EditCommand { get; private set; }
        public CommandHandler DeleteCommand { get; private set; }
        public ObservableCollection<handphone> Source { get; private set; }
        public List<Photo> ListPhoto { get; set; }
        public CollectionView ListPhotoView { get; set; }

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
            }
        }

        public CommandHandler AddPhoto { get; private set; }

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

        private IDataCollection<handphone> data = new HandphoneCollection();
        private handphone _selected;

        public HandphoneVM()
        {
            ListPhoto = new List<Photo>();
            ListPhotoView = (CollectionView)CollectionViewSource.GetDefaultView(ListPhoto);
            AddPhoto = new CommandHandler { CanExecuteAction = x => SelectedItem != null, ExecuteAction = AddPhotoAction };

            AddCommand = new CommandHandler { CanExecuteAction = addCommandvalidation, ExecuteAction = addCommandAction };
            EditCommand = new CommandHandler { CanExecuteAction = editCommandValidation, ExecuteAction = editCommandAction };
            DeleteCommand = new CommandHandler { CanExecuteAction = deleteCommandValidation, ExecuteAction = deleteCommandAction };
            Source = new ObservableCollection<handphone>(data.GetData());
            SourceView = (CollectionView)CollectionViewSource.GetDefaultView(Source);

        }
        private void AddPhotoAction(object obj)
        {
            var form = new Forms.AddPhotoView(SelectedItem, PhotoType.Handphone);
            form.ShowDialog();

            if (form.Model != null)
            {
                this.ListPhoto.Add(form.Model);
            }


        }
        private void deleteCommandAction(object obj)
        {
            var dialig = MessageBox.Show("Yakin Menghapus data ?", "Confirm", MessageBoxButton.YesNo);
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

        private void editCommandAction(object obj)
        {

            var form = new Forms.addHandphoneView();
            var vm = new AddHandphoneVM(ChangeStatus.Edit, Source, SourceView, SelectedItem) { WindowClose = form.Close };
            form.DataContext = vm;
            form.ShowDialog();
        }

        private void addCommandAction(object obj)
        {
           
            var form = new Forms.addHandphoneView();
            var vm = new AddHandphoneVM(ChangeStatus.New, Source, SourceView, SelectedItem) { WindowClose=form.Close } ;
            form.DataContext = vm;
            form.ShowDialog();
        }

        private bool deleteCommandValidation(object obj)
        {
            return SelectedItem != null ? true : false;
        }

        private bool editCommandValidation(object obj)
        {
            return SelectedItem != null ? true : false;
        }

        private bool addCommandvalidation(object obj)
        {
            return true;
        }
    }
}
