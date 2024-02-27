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
            txtCaptcha.Visibility = Visibility.Collapsed;
            textBlockCaptcha.Visibility = Visibility.Collapsed;
        }
        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client()); //Позволяет переместиться на другую страницу
        }
        /// <summary>
        /// Этот метод реализует авторизацию пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
            string login = txtbLogin.Text.Trim();
            string password = pswbPassword.Text.Trim();
            User user = new User();
            string hashpass = HashPassword.HashPassword1(password); //Хэшируем введенный пользователем пароль
            user = Model1.GetContext().User.Where(p => (p.Login == login) && (p.Parol == hashpass)).FirstOrDefault(); /*Ищем пользователя с тем 
                                                                                                                       *паролем и логином, что ввел пользователь*/
            
            if (UnsuccessFul < 2) //Проверка нужная для вывода капчи, если неудачных попыток входа меньше двух, то пользователь может вводить свои данные
            {
                if(user != null) //Истина тогда, когда пользователь ввел верные данные, которые есть в базе данных
                {
                    string userFIO = user.Sotrudniki.First().Imea.ToString() + " " + user.Sotrudniki.First().Familia.ToString(); //Получаем имя и фамилию пользователя
                    MessageBox.Show("Вы вошли в систему, "+userFIO+"!");
                    LoadForm(user.Sotrudniki.First().ID_dolzhnosti.ToString(), userFIO);//Загружаем страницу по должности
                }
                else 
                {
                    
                    MessageBox.Show("Введите данные заново!");
                    UnsuccessFul++; //Увеличиваем пееменную, которая считает попытки неудачного входа
                    txtbLogin.Text = null; //Очищаем поля ввода логина и пароля, чтобы каждый раз при неверном вводе пароля не приходилось очищать поля самому
                    pswbPassword.Text = null;
                    textBlockCaptcha.Text = GanerateCapcha(3); //Генерируем капчу
                }
            }
            else
            {
                string CaptchaInput = txtCaptcha.Text;
                textBlockCaptcha.Visibility = Visibility.Visible;
                txtbLogin.IsEnabled = false;//Делаем поля неактивными, пока пользователь не введет капчу правильно
                pswbPassword.IsEnabled = false;
                txtCaptcha.Visibility = Visibility.Visible;
                btnEnter.Content = "Подтвердить";
                if (CaptchaInput == textBlockCaptcha.Text)
                {
                    btnEnter.Content = "Войти";
                    UnsuccessFul = 0; //Обнуляем счетчик, когда пользователь верно ввел капчу
                    textBlockCaptcha.Visibility = Visibility.Collapsed;
                    txtbLogin.IsEnabled = true; //Снова делаем поля активными
                    pswbPassword.IsEnabled = true;
                    txtCaptcha.Visibility = Visibility.Collapsed;
                }
                else if (error < 3)
                {
                    MessageBox.Show("Каптча введена неверно!");
                    error++; //Считаем количесво неправильно введенных капч
                    txtCaptcha.Clear();
                    textBlockCaptcha.Text = GanerateCapcha(3);
                }
                else
                {
                    MessageBox.Show("Доступ заблокирован!");
                    txtCaptcha.Visibility = Visibility.Visible;
                    textBlockCaptcha.IsEnabled = false; //Так как доступ заблокирован делаем поля неактивными
                    txtCaptcha.IsEnabled = false;
                    pswbPassword.IsEnabled = false;
                    error = 0;
                    btnEnter.IsEnabled = false;
                    for (int i = 10; i >= 0; i--) //Блокируем доступ на 10 секунд
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
        /// <summary>
        /// Метод реализующий генерацию капчи
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        private string GanerateCapcha(int Length)
        {
            string chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789!@#$%^&*_";//Пишем символы с клавиатуры, которые будем использовать 
            Random rnd = new Random();
            char[] capchaChars = new char[Length];
            for (int i = 0; i < Length; i++)//Случайным образом генерируем капчу из заданного количества символов
            {
                capchaChars[i] = chars[rnd.Next(chars.Length)];
            }
            return new string (capchaChars);
        }
        /// <summary>
        /// В этом методе реализуем переход авторизовавшегося пользователя на страницу, соответствующую его должности
        /// </summary>
        /// <param name="_role"></param>
        /// <param name="userFIO"></param>
        private void LoadForm(string _role, string userFIO)
        {
            switch (_role)
            {
                case "1":
                    NavigationService.Navigate(new Director(userFIO));//Передаем переменную с именем и фамилией пользователя в класс Директора
                    MessageBox.Show("Директор");
                    break;
                case "2":
                    NavigationService.Navigate(new OfficeWorker(userFIO));
                    MessageBox.Show("Офисный работник");
                    break;
                case "3":
                    NavigationService.Navigate(new Agent(userFIO));
                    MessageBox.Show("Агент");
                    break;
                case "4":
                    NavigationService.Navigate(new Vahter(userFIO));
                    MessageBox.Show("Вахтер");
                    break;
            }
        }
    }
}
