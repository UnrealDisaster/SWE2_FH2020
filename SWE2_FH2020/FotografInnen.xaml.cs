using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SWE2_FH2020
{
    /// <summary>
    /// Interaction logic for FotografInnen.xaml
    /// </summary>
    public partial class FotografInnen : Window
    {
        public FotografInnen()
        {
            DataContext = new FotografInnenViewModel();
            InitializeComponent();
        }
        private void Delete_Fotograf(object sender, RoutedEventArgs e)
        {
            BL test = new BL();
            var button = (Button)sender;
            test.delPhotographer(button.Tag.ToString());
            Console.WriteLine(button.Tag);
            var f = (FotografInnenViewModel)DataContext;
            f.FotografGeloescht();
        }
    }
}
