using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TopsisLIB;
using TopsisLIB.DataCollections;
using TopsisLIB.Models;

namespace SPKWithTopsis.Forms
{
    /// <summary>
    /// Interaction logic for AddPhotoView.xaml
    /// </summary>
    public partial class AddPhotoView : Window
    {
        private handphone selectedhandphone;
        private computer selectedcomputer;
        private PhotoType photoType;

        public Photo Model { get; private set; }

        public AddPhotoView(computer selectedItem, PhotoType phototype)
        {
            InitializeComponent();
            this.selectedcomputer = selectedItem;
            this.photoType = phototype;
            this.ChangePhoto();
        }

        public AddPhotoView(handphone selectedItem, PhotoType phototype)
        {
            InitializeComponent();
            this.selectedhandphone = selectedItem;
            this.photoType = phototype;
            this.ChangePhoto();
        }

        private void ChangePhoto()
        {

            Gat.Controls.OpenDialogView openDialog = new Gat.Controls.OpenDialogView();
            Gat.Controls.OpenDialogViewModel vm = (Gat.Controls.OpenDialogViewModel)openDialog.DataContext;

            // Adding file filter
            vm.AddFileFilterExtension(".jpg;.png");

            // Show dialog and take result into account
            bool? result = vm.Show();
            if (result == true)
            {
                // Get selected file path
                var txt = vm.SelectedFilePath;
                image1.Source = new BitmapImage(new Uri(txt));
            }
            else
            {
                var txt = string.Empty;
            }
        }

        private void Change_click(object sender, RoutedEventArgs e)
        {
            ChangePhoto();
        }

        private void SaveImage(object sender, RoutedEventArgs e)
        {

            var bits = ConvertBitmapSourceToByteArray(image1.Source);
            Photo item = null;
            if(photoType== PhotoType.Laptop)
             item = new Photo { Id = 0, ProductId = selectedcomputer.Id, ProductType = photoType, photo = bits };
            else
                item = new Photo { Id = 0, ProductId = selectedhandphone.Id, ProductType = photoType, photo = bits };


            var dc = new PhotoCollection();
           var id= dc.Add(item);
            if (id > 0)
            {
                this.Model = item;
            }
            else
                this.Model = null; 
        }

        public static byte[] ConvertBitmapSourceToByteArray(ImageSource imageSource)
        {
            var image = imageSource as BitmapSource;
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }

    }
}
