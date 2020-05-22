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

        private string _filter = "";

        public string filter {
            get {
                return _filter;
            }
            set {
                _filter = value;
                OnPropertyChanged("PictureList");
            }
        }

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
                        b.ToolTip = fileName.Split('\\').Last();
                        b.Child = img;
                        b.MouseDown += MouseButtonDownHandler;
                        list.Add(b);
                    }

                    _selectedImage = (Image)list.Last().Child;
                    _pictureList = list;
                }

                if(filter.Length > 0)
                {
                    List<Border> temp = new List<Border>();
                    foreach(Border b in _pictureList)
                    {
                        Console.WriteLine("toolTip: " + b.ToolTip.ToString());
                        if (b.ToolTip.ToString().StartsWith(filter))
                            temp.Add(b);
                    }
                    Console.WriteLine("Returned Filterd !!! ");
                    return temp;
                }

                Console.WriteLine("Returned Un-Filterd !!! ");
                return _pictureList;
            }
        }

        private void ResetBorders()
        {
            foreach ( var b in _pictureList)
            {
                b.BorderBrush = Brushes.White;
            }
        }
        private void MouseButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border)
            {
                var b = (Border)sender;
                ResetBorders();
                b.BorderBrush = Brushes.Red;
                _selectedImage = (Image)b.Child;
                OnPropertyChanged("selectedImage");
            }
        }
    }
}
