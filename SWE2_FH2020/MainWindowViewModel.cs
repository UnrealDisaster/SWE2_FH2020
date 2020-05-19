using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SWE2_FH2020
{
    class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            EventHandler<PropertyChangedEventArgs> eh = new EventHandler<PropertyChangedEventArgs>(ChildChanged);
            _imageViewModel.PropertyChanged += (s, e) => OnPropertyChanged("selectedImage");
        }
        private ImageViewModel _imageViewModel = new ImageViewModel();

        public ImageViewModel ImageViewModel {
            get {
                return _imageViewModel;
            }
        }

        public string selectedImage {
            get {
                if (_imageViewModel.selectedImage == null)
                {
                    return "nope ";
                }
                return _imageViewModel.selectedImage.Source.ToString();
            }
        }
        public void ChildChanged(object sender, PropertyChangedEventArgs e)
        {

        }
    }
}
