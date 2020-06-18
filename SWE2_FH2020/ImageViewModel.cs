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

        private string _selectedImage = null;

        public string selectedImage {
            get {
                return _selectedImage;
            }
        }
        List<Border> _images = null;
        List<Picture> _pictureData = new List<Picture>();

        private Picture _selectedPictureData = null;
        public Picture selectedPictureData {
            get {
                return _selectedPictureData;
            }
        }
        public IEnumerable<Border> PictureList {
            get {
                if (_images == null)
                {
                    var bl = new BL();
                    var ph = bl.getPhotographers();

                    string startupPath = System.IO.Directory.GetCurrentDirectory();
                    string path = startupPath + "../../../../res";

                    List<Border> list = new List<Border>();
                    int i = 1;

                    var rand = new Random();
                    foreach (string fileName in Directory.GetFiles(path))
                    {
                        Console.WriteLine("11111111111111111");
                        var p = Picture.randomPicture(fileName.Split('\\').Last(),i,i);
                        p.setId(i);
                        p.setPhotographerId(ph[rand.Next()%ph.Count()].getId());
                        Console.WriteLine("222222222222222");
                        _pictureData.Add(p);
                        Console.WriteLine(p.getExif().getDateTime());
                        Console.WriteLine(p.getExif().getIsoSpeedRating());
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
                        Console.WriteLine("333333333333333333");
                        i++;
                    }

                    bl.setupPicturesData(_pictureData);

                    _selectedImage = ((Image)list.Last().Child).Source.ToString();
                    _selectedPictureData = _pictureData.Last();
                    _images = list;
                }

                if(filter.Length > 0)
                {
                    List<Border> temp = new List<Border>();
                    foreach(Border b in _images)
                    {
                        Console.WriteLine("toolTip: " + b.ToolTip.ToString());
                        if (b.ToolTip.ToString().StartsWith(filter))
                            temp.Add(b);
                    }
                    Console.WriteLine("Returned Filterd !!! ");
                    return temp;
                }

                Console.WriteLine("Returned Un-Filterd !!! ");
                return _images;
            }
        }

        private void ResetBorders()
        {
            foreach ( var b in _images)
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
                _selectedImage = ((Image)b.Child).Source.ToString() ;

                string tt = (string)b.ToolTip;
                foreach(var p in _pictureData)
                {
                    if(p.getDirectory() == tt)
                    {
                        _selectedPictureData = p;
                        break;
                    }
                }

                var ex = _selectedPictureData.getExif();
                var ip = _selectedPictureData.getIptc();
                Console.WriteLine(ex.getDateTime() + " " + ex.getExposureTime());
                Console.WriteLine(ip.getByLine() + " " +ip.getCopyright());
                OnPropertyChanged("");
            }
        }
    }
}
