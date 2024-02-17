using System;
using System.CodeDom.Compiler;
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
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        private int UnsuccessFul = 0;
        private int error = 0;
        public Autho()
        {
            InitializeComponent();
            txtCaptcha.Visibility = Visibility.Hidden;
            textBlockCaptcha.Visibility = Visibility.Hidden;
        }

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client());
        }
        
        private async void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
            string login = txtbLogin.Text.Trim();
            string password = pswbPassword.Text.Trim();
            //Sotrudniki sotr = new Sotrudniki();
            //Dolzhnosti dolzhnosti = new Dolzhnosti();
            User user = new User();
            string hashpass = HashPassword.HashPassword1(password);
            user = Model1.GetContext().User.Where(p => (p.Login == login) && (p.Parol == hashpass)).FirstOrDefault();
            
            
            //int userCount = ModelForProject.GetContext().User.Where(p => p.Login == login && p.Parol == password).Count();
            if (UnsuccessFul < 2)
            {
                if(user != null)
                {
                    string userFIO = user.Sotrudniki.First().Imea.ToString() + " " + user.Sotrudniki.First().Familia.ToString();
                    MessageBox.Show("Вы вошли в систему! "+userFIO);
                    LoadForm(user.Sotrudniki.First().ID_dolzhnosti.ToString(), userFIO);
                }
                else
                {
                    
                    MessageBox.Show("Введите данные заново!");
                    UnsuccessFul++;
                    txtbLogin.Text = null;
                    pswbPassword.Text = null;
                    textBlockCaptcha.Text = GanerateCapcha(3);
                    //textBlockCaptcha.Visibility = Visibility.Collapsed;
                    //txtCaptcha.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                
                string CaptchaInput = txtCaptcha.Text;
                textBlockCaptcha.Visibility = Visibility.Visible;
                txtbLogin.IsEnabled = false;
                pswbPassword.IsEnabled = false;
                txtCaptcha.Visibility = Visibility.Visible;
                btnEnter.Content = "Подтвердить";
                if (CaptchaInput == textBlockCaptcha.Text)
                {
                    btnEnter.Content = "Войти";
                    UnsuccessFul = 0;
                    textBlockCaptcha.Visibility = Visibility.Hidden;
                    txtbLogin.IsEnabled = true;
                    pswbPassword.IsEnabled = true;
                    txtCaptcha.Visibility = Visibility.Hidden;
                }
                else if (error < 3)
                {
                    MessageBox.Show("Каптча введена неверно!");
                    error++;
                    txtCaptcha.Clear();
                    textBlockCaptcha.Text = GanerateCapcha(3);
                }
                else
                {
                    MessageBox.Show("Доступ заблокирован!");
                    txtCaptcha.Visibility = Visibility.Visible;
                    textBlockCaptcha.IsEnabled = false;
                    txtCaptcha.IsEnabled = false;
                    pswbPassword.IsEnabled = false;
                    error = 0;
                    btnEnter.IsEnabled = false;
                    for (int i = 10; i >= 0; i--)
                    {
                        txtCaptcha.Text = String.Format("До разблокировки осталось {0} секунд", i);
                        await Task.Delay(1000);
                        
                    }
                    btnEnter.IsEnabled = true;
                    txtCaptcha.Text = null;
                    txtCaptcha.IsEnabled = true;
                    textBlockCaptcha.IsEnabled = true;
                }
            }
        }
        private string GanerateCapcha(int Length)
        {
            string chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789!@#$%^&*_";
            Random rnd = new Random();
            char[] capchaChars = new char[Length];
            for (int i = 0; i < Length; i++)
            {
                capchaChars[i] = chars[rnd.Next(chars.Length)];
            }
            return new string (capchaChars);
        }
        private void LoadForm(string _role, string userFIO)
        {
            //NavigationService.Navigate(new Client());
            switch (_role)
            {
                case "1":
                    NavigationService.Navigate(new Director(userFIO));
                    MessageBox.Show("Директор");//у этой роли права редактирования
                    break;
                case "2":
                    NavigationService.Navigate(new OfficeWorker());
                    MessageBox.Show("Офисный работник");
                    break;
                case "3":
                    NavigationService.Navigate(new Agent(userFIO));
                    MessageBox.Show("Агент");
                    break;
                case "4":
                    NavigationService.Navigate(new Vahter());
                    MessageBox.Show("Вахтер");
                    break;
            }
        }
    }
}
