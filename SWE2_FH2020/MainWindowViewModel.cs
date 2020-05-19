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
                    return "";
                }
                return _imageViewModel.selectedImage.Source.ToString();
            }
        }
    }
}
