using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SWE2_FH2020
{

    public class ImageViewModel : ViewModel
    {

        private Image _selectedImage = null;

        public Image selectedImage {
            get {
                return _selectedImage;
            }
        }

        List<Border> _pictureList = null;
        public IEnumerable<Border> PictureList {
            get {
                if (_pictureList == null)
                {
                    string startupPath = System.IO.Directory.GetCurrentDirectory();
                    string path = startupPath + "../../../../res";

                    List<Border> list = new List<Border>();

                    foreach (string fileName in Directory.GetFiles(path))
                    {
                        var b = new Border();
                        b.BorderThickness = new Thickness(2.0);
                        var img = new Image();
                        var uri = new Uri(fileName, UriKind.Absolute);
                        var bmi = new BitmapImage(uri);
                        img.Source = bmi;
                        _selectedImage = img;
                        b.Child = img;
                        b.MouseDown += MouseButtonDownHandler1;
                        list.Add(b);
                    }
                    _pictureList = list;
                }
                return _pictureList;
            }
        }

        private void ResetBorder()
        {
            foreach ( var b in _pictureList)
            {
                b.BorderBrush = Brushes.White;
            }
        }
        private void MouseButtonDownHandler1(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border)
            {
                var b = (Border)sender;
                ResetBorder();
                b.BorderBrush = Brushes.Red;
                _selectedImage = (Image)b.Child;
                OnPropertyChanged("selectedImage");
            }
        }
    }
}
