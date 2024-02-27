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

namespace Konuk_pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для OfficeWorker.xaml
    /// </summary>
    public partial class OfficeWorker : Page
    {
        public OfficeWorker(string userFIO)
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
                return tbTime.Text = "Доброе утро";
            }
            else if (timeNow.Hour > 11 && timeNow.Minute >= 1 && timeNow.Hour <= 17)
            {
                return tbTime.Text = "Добрый день";
            }
            else if (timeNow.Hour > 16 && timeNow.Minute >= 1 && timeNow.Hour <= 19)
            {
                return tbTime.Text = "Добрый вечер";
            }
            else
            {
                tbFIO.Visibility = Visibility.Collapsed;
                return tbTime.Text = "Доступ заблокирован! Зайдите позже!";
            }
        }
    }
}
