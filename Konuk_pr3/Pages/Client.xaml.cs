using Konuk_pr3.Model;
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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client()
        {
            InitializeComponent();
            //User user = new User();
            //Sotrudniki sotr = new Sotrudniki();
            //sotr = ModelForProject.GetContext().Sotrudniki.Where(p => p.id_user == user.id_user).FirstOrDefault();
            //string imea = sotr.Imia;
            //string familia = sotr.Familia;
            //string Otchestvo = sotr.Otchestvo;
            //tbFIO.Text = imea+" "+familia+" "+Otchestvo;
        }
    }
}
