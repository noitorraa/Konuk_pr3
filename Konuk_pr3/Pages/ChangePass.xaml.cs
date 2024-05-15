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
    /// Логика взаимодействия для ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Page
    {
        private User user = new User();
        private Sotrudniki sotr = new Sotrudniki();
        public ChangePass(string mail)
        {
            InitializeComponent();
            sotr = Model1.GetContext().Sotrudniki.Where(t => t.Adres == mail).FirstOrDefault();
            user = Model1.GetContext().User.Where(t => t.ID_user == sotr.id_user).FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_Pass1.Text == tb_pass2.Text && tb_Pass1.Text != string.Empty && tb_pass2.Text != string.Empty)
            {
                user.Parol = HashPassword.HashPassword1(tb_Pass1.Text);
                try
                {
                    Model1.GetContext().SaveChanges();
                    MessageBox.Show("Пароль изменен");
                    this.NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("При сохранении изменений возникла следующая ошибка "+ex);
                }
                
            }
        }
    }
}
