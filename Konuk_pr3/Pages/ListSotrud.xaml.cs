using System;
using System.Collections.Generic;
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
using Konuk_pr3.Model;
using ConsoleApp2;

namespace Konuk_pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListSotrud.xaml
    /// </summary>
    public partial class ListSotrud : Page
    {
        List<Sotrudniki> sotrudniki;
        public ListSotrud()
        {
            InitializeComponent();
            sotrudniki = Model1.GetContext().Sotrudniki.ToList();
            LbSpisok.ItemsSource = sotrudniki;
            cmb_filter.SelectedIndex = 0;
            cmb_filter2.SelectedIndex = 0;
        }

        private void btn_sort_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton(object sender, RoutedEventArgs e)
        {

        }

        private void LbSpisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
