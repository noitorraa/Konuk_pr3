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
using ConsoleApp2.Model;
using System.ComponentModel.DataAnnotations;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;
using Model1 = Konuk_pr3.Model.Model1;
using User = Konuk_pr3.Model.User;
using Sotrudniki = Konuk_pr3.Model.Sotrudniki;

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
            tbLogin.Text = user.Login;
            tbOtchestvo.Text = sotr.Otchestvo;
            tbNomerTelefona.Text = Convert.ToString(sotr.Telephon);
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
                sotr.Imea = tbImia.Text;
                sotr.Familia = tbFamilia.Text;
                sotr.Otchestvo = tbOtchestvo.Text;
                sotr.Adres = tbAdres.Text;
                user.Login = tbLogin.Text;
                sotr.Telephon = tbNomerTelefona.Text;
                Helper helper = new Helper();
                var contextSotr = new ValidationContext(sotr);
                var results = new List<ValidationResult>();
                try
                {
                    if (!Validator.TryValidateObject(sotr, contextSotr, results, true))
                    {
                        foreach (var error in results)
                        {
                            MessageBox.Show(error.ErrorMessage);
                        }
                    }
                    else
                    {
                        Model1.GetContext().SaveChanges();
                        MessageBox.Show("Изменения сохранены!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Возникла следующая ошибка " + ex);
                }
            
        }
    }
}
