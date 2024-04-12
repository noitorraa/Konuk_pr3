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
        private User user = new User();
        private Sotrudniki sotr = new Sotrudniki();
        public CurrentUser(int kod_sotrudnika)
        {
            InitializeComponent();
            kod = kod_sotrudnika;
            sotr = Model1.GetContext().Sotrudniki.Where(t => t.ID_sotrudnika == kod_sotrudnika).FirstOrDefault();
            user = Model1.GetContext().User.Where(t => t.ID_user == sotr.id_user).FirstOrDefault();
            tbImia.Text = sotr.Imea;
            tbFamilia.Text = sotr.Familia;
            tbAdres.Text = sotr.Adres;
            //tbLogin.Text = sotr.User.Login;
            tbLogin.Text = user.Login;
            tbOtchestvo.Text = sotr.Otchestvo;
            tbNomerTelefona.Text = Convert.ToString(sotr.Telephon);
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbAdres.Text == string.Empty || tbFamilia.Text == string.Empty || tbImia.Text == string.Empty || tbLogin.Text == string.Empty || tbNomerTelefona.Text == string.Empty || tbOtchestvo.Text == string.Empty)
            {
                MessageBox.Show("Заполните поля, чтобы изменить данные");
            }
            else
            {
                sotr.Imea = tbImia.Text;
                sotr.Familia = tbFamilia.Text;
                sotr.Otchestvo = tbOtchestvo.Text;
                sotr.Adres = tbAdres.Text;
                user.Login = tbLogin.Text;
                int i;
                bool res = int.TryParse(tbNomerTelefona.Text, out i);
                if (res == true)
                {
                    sotr.Telephon = Convert.ToInt32(tbNomerTelefona.Text);
                    Helper helper = new Helper();
                    try
                    {
                        //helper.UpdateUsers(user); // Нужно сохранить изменения
                        Model1.GetContext().SaveChanges();
                        MessageBox.Show("Изменения сохранены!");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Возеикла следующая ошибка " + ex);
                    }
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
}
