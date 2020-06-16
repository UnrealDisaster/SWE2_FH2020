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
            _searchViewModel.PropertyChanged += (s, e) => searchWordChanged();


        }

        private void searchWordChanged()
        {
            _imageViewModel.filter = _searchViewModel.Text;
        }

        private ImageViewModel _imageViewModel = new ImageViewModel();
        public ImageViewModel ImageViewModel {
            get {
                return _imageViewModel;
            }
        }

        private SearchViewModel _searchViewModel = new SearchViewModel();
        public SearchViewModel SearchViewModel {
            set {
                _searchViewModel = value;
            }
            get {
                return _searchViewModel;
            }
        }
        public string searchWord {
            get {
                return _searchViewModel.Text;
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



        private ICommandViewModel _LayoutsCommand;
        public ICommandViewModel LayoutsCommand {
            get {
                if (_LayoutsCommand == null)
                {
                    _LayoutsCommand = new SimpleCommandViewModel(
                        "FotografInnen",
                        "Öffnet das Layout Beispiel",
                        () =>
                        {
                            var dlg = new FotografInnen();
                            dlg.ShowDialog();
                        });
                }
                return _LayoutsCommand;
            }
        }
    }
}
