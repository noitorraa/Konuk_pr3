using Konuk_pr3.Pages;
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

namespace Konuk_pr3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FraMain.Navigate(new Autho()); //Осуществляем переход на основную страницу
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FraMain.GoBack(); //Кнопка для возвращения на предыдущий экран
        }
        /// <summary>
        /// Этот метод не позволяет вернуться на предыдущую странницу, если это начальная страница
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FraMain_ContentRendered(object sender, EventArgs e)
        {
            if (FraMain.CanGoBack) { btnBack.Visibility = Visibility.Visible; }
            else { btnBack.Visibility = Visibility.Hidden; }
        }
    }
}
