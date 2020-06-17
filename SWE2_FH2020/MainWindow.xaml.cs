using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SWE2_FH2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            var iv = new MainWindowViewModel();
            this.DataContext = iv;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Button_Click");
        }
        private void Open_Fotografen(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Wörks");
        }
    }
}
