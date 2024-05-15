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

namespace Konuk_pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Director.xaml
    /// </summary>
    public partial class Director : Page
    {
        private bool InTime = true;
        public Director(string userFIO)
        {
            InitializeComponent();
            TimeLock();
            tbFIO.Text = userFIO;
        }
        public string TimeLock()
        {
            DateTime timeNow = DateTime.Now;
            if (timeNow.Hour >= 10 && timeNow.Hour <= 12)
            {
                InTime = true;
                return tbTime.Text = "Доброе утро";
            }
            else if (timeNow.Hour > 11 && timeNow.Minute >= 1 && timeNow.Hour <= 17)
            {
                InTime = true;
                return tbTime.Text = "Добрый день";
            }
            else if (timeNow.Hour > 16 && timeNow.Minute >= 1 && timeNow.Hour <= 19)
            {
                InTime = true;
                return tbTime.Text = "Добрый вечер";
            }
            else
            {
                InTime = false;
                tbFIO.Visibility = Visibility.Collapsed;
                return tbTime.Text = "Доступ заблокирован! Зайдите позже!";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (InTime)
            //{
                NavigationService.Navigate(new ListSotrud());
            //}
            //else
            //{
            //    MessageBox.Show("Рабочий день окончен, зайдите позже!");
            //}
        }
    }
}
