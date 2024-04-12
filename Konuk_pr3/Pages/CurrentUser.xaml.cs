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
using HashPasswords;

namespace Konuk_pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для CurrentUser.xaml
    /// </summary>
    public partial class CurrentUser : Page
    {
        public int kod;
        public CurrentUser(int kod_sotrudnika)
        {
            kod = kod_sotrudnika;
            InitializeComponent();
            Sotrudniki sotr = new Sotrudniki();
            sotr = Model1.GetContext().Sotrudniki.Where(t => t.ID_sotrudnika == kod_sotrudnika).FirstOrDefault();
            tbImia.Text = sotr.Imea;
            tbFamilia.Text = sotr.Familia;
            tbAdres.Text = sotr.Adres;
            tbLogin.Text = sotr.User.Login;
            tbOtchestvo.Text = sotr.Otchestvo;
            tbNomerTelefona.Text = Convert.ToString(sotr.Telephon);
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            Sotrudniki sotrudniki = new Sotrudniki();
            sotrudniki = Model1.GetContext().Sotrudniki.Where(t => t.ID_sotrudnika == kod).FirstOrDefault();
            user = Model1.GetContext().User.Where(t => t.ID_user == sotrudniki.id_user).FirstOrDefault();
            sotrudniki.Imea = tbImia.Text;
            sotrudniki.Familia = tbFamilia.Text;
            sotrudniki.Otchestvo = tbOtchestvo.Text;
            sotrudniki.Adres = tbAdres.Text;
            user.Login = tbLogin.Text;
            int i;
            bool res = int.TryParse(tbNomerTelefona.Text, out i);
            if (res == true)
            {
                sotrudniki.Telephon = Convert.ToInt32(tbNomerTelefona.Text);
                Helper helper = new Helper();
                //helper.UpdateUsers(user); // Нужно сохранить изменения
                //Model1.GetContext().SaveChanges();
                //Model1.GetContext().User.Add(user);
                //Model1.GetContext().SaveChanges();
                //sotrudniki.id_user = user.ID_user;
                //Model1.GetContext().Sotrudniki.Add(sotrudniki);
                //Model1.GetContext().SaveChanges();
                
                //helper.UpdateSotr(sotrudniki);
                //MessageBox.Show("Успешно изменено");
            }
        }
    }
}
