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
            _imageViewModel.PropertyChanged += (s, e) => OnPropertyChanged("selectedIptcDate");
            _imageViewModel.PropertyChanged += (s, e) => OnPropertyChanged("selectedIptcTime");
            _imageViewModel.PropertyChanged += (s, e) => OnPropertyChanged("selectedIptcByLine");
            _imageViewModel.PropertyChanged += (s, e) => OnPropertyChanged("selectedIptcCopyright");
            _imageViewModel.PropertyChanged += (s, e) => OnPropertyChanged("CurrentPhotographer");

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
                return _imageViewModel.selectedImage;
            }
        }

        public Picture selectedPictureData {
            get {
                Console.WriteLine("selectedPictureData get");
                if (_imageViewModel.selectedImage == null)
                {
                    return null;
                }
                return _imageViewModel.selectedPictureData;
            }
        }

        public DateTime selectedIptcDate {
            get {
                Console.WriteLine("selectedIptcDate get");
                if (_imageViewModel.selectedImage == null)
                {
                    return new DateTime(1, 1, 1);
                }
                return _imageViewModel.selectedPictureData.getIptc().getDate();
            }
            set {
                _imageViewModel.selectedPictureData.getIptc().setDate(value);
            }
        }

        public string selectedIptcTime {
            get {
                if (_imageViewModel.selectedImage == null)
                {
                    return "";
                }
                return _imageViewModel.selectedPictureData.getIptc().getTime().ToString();
            }
            set {
                string[] time = value.Split(":");
                _imageViewModel.selectedPictureData.getIptc().setTime(new TimeSpan(Int32.Parse(time[0]), Int32.Parse(time[1]), Int32.Parse(time[2])));
            }
        }

        public string selectedIptcByLine {
            get {
                if (_imageViewModel.selectedImage == null)
                {
                    return "";
                }
                return _imageViewModel.selectedPictureData.getIptc().getByLine();
            }
            set {
                _imageViewModel.selectedPictureData.getIptc().setByLine(value);
            }
        }

        public string selectedIptcCopyright {
            get {
                if (_imageViewModel.selectedImage == null)
                {
                    return "";
                }
                return _imageViewModel.selectedPictureData.getIptc().getCopyright();
            }
            set {
                _imageViewModel.selectedPictureData.getIptc().setCopyright(value);
            }
        }

        public void printPdf()
        {
            var bl = new BL();
            bl.printReport(_imageViewModel.selectedPictureData);
        }
        public void saveSelectedIPTC()
        {
            var bl = new BL();
            bl.savePictureData(selectedPictureData);
        }


        public IEnumerable<ComboBoxItem> YAxes{
            get{
                var bl = new BL();
                var ya = new List<ComboBoxItem>();
                foreach(string s in bl.photographerList())
                {
                    var cbi = new ComboBoxItem();
                    cbi.Content = s;
                    ya.Add(cbi);
                }
                return ya;
            }
        }

        private string _selectedPhotographer = "";
        public string SelectedPhotographer {
            get {
                return _selectedPhotographer;
            }
            set {
                _selectedPhotographer = value;
            }
        }

        public void saveSelectedPhotographer()
        {
            var bl = new BL();
            Console.WriteLine("______________"+selectedPictureData.getId() + " " + _selectedPhotographer.Split(": ")[1]);
            bl.setPhotographerToPic(selectedPictureData.getId(), _selectedPhotographer.Split(": ")[1]);
            OnPropertyChanged("CurrentPhotographer");
        }

        public string CurrentPhotographer {
            get {
                if (selectedPictureData == null)
                    return "";
                var bl = new BL();
                return bl.getNamebyPic(selectedPictureData.getId());
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
