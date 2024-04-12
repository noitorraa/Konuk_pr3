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
using Konuk_pr3;

namespace Konuk_pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для SotrudList.xaml
    /// </summary>
    public partial class SotrudList : Page
    {
        public SotrudList()
        {
            InitializeComponent();
            
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {

            if (tbAdres.Text == string.Empty || tbFamilia.Text == string.Empty || tbImia.Text == string.Empty || tbLogin.Text == string.Empty || tbNomerTelefona.Text == string.Empty || tbOtchestvo.Text == string.Empty || tbparol.Text == string.Empty)
            {
                MessageBox.Show("Заполните поля, чтобы создатьнового пользователя");
            }
            else
            {
                Sotrudniki sotrudniki = new Sotrudniki();
                User user = new User();
                sotrudniki.Imea = tbImia.Text;
                sotrudniki.Familia = tbFamilia.Text;
                sotrudniki.Otchestvo = tbOtchestvo.Text;
                sotrudniki.Adres = tbAdres.Text;
                user.Login = tbLogin.Text;
                user.Parol = HashPassword.HashPassword1(tbparol.Text);
                
                int i;
                bool res = int.TryParse(tbNomerTelefona.Text, out i);
                if (res == true)
                {
                    sotrudniki.Telephon = Convert.ToInt32(tbNomerTelefona.Text);
                    switch (cmbRol.Text)
                    {
                        case "Директор":
                            sotrudniki.ID_dolzhnosti = 1;
                            break;
                        case "Офисный работник":
                            sotrudniki.ID_dolzhnosti = 2;
                            break;
                        case "Вахтер":
                            sotrudniki.ID_dolzhnosti = 4;
                            break;
                        case "Агент":
                            sotrudniki.ID_dolzhnosti = 3;
                            break;
                    }
                    Helper helper = new Helper();
                    helper.CreateUsers(user);
                    sotrudniki.id_user = user.ID_user;
                    helper.CreateSotr(sotrudniki);
                    
                    MessageBox.Show("Новый пользователь успешно создан!");
                }
                else
                {
                    MessageBox.Show("В номере телефона не может быть символов!");
                    tbNomerTelefona.Clear();
                }
            }
        }
    }
}
