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
using System.Net.Mail;
using System.Net;
using ConsoleApp2.Model;
namespace Konuk_pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для RestorePassword.xaml
    /// </summary>
    public partial class RestorePassword : Page
    {
        public RestorePassword()
        {
            InitializeComponent();
        }
        private string mail;
        private int KOD;
        //private Sotrudniki sotr = new Sotrudniki();
        User user = new User();
        private void btn_mail_Click(object sender, RoutedEventArgs e)
        {
            tb_KodForRestore.Visibility = Visibility.Visible;
            tb_sendKod.Visibility = Visibility.Visible;
            btn_Done.Visibility = Visibility.Visible;
            mail = tb_mail.Text;
            
            SendMessage();
            Dellay();
        }
        
        private async void Dellay()
        {
            btn_mail.IsEnabled = false;
            tb_mail.IsEnabled = false;
            for (int i = 60; i >= 0; i--)
            {   
                btn_mail.Content = "Повторить отправку";  
                
                tb_mail.Text = String.Format("Повторить отправку через {0}", i);
                await Task.Delay(1000);
                
            }
            tb_mail.IsEnabled = true;
            btn_mail.IsEnabled = true;
            tb_mail.Clear();
        }
        private void SendMessage()
        { 
            try
            {
                Random rnd = new Random();
                KOD = rnd.Next(1000, 9999);
                MailAddress from = new MailAddress("ivankonuk00@gmail.com", "Admin");

                MailAddress to = new MailAddress(mail);

                MailMessage m = new MailMessage(from, to);

                m.Subject = "Восстановление пароля";

                m.Body = String.Format("<h2>Для восстановления пароля введите следующий код {0} если это не вы пытаетесь восстановить пароль, то просто игнорируйте это письмо.</h2>", KOD);

                m.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.Credentials = new NetworkCredential("ivankonuk00@gmail.com", "yzzm iuca jhjz ayih");
                smtp.EnableSsl = true;
                smtp.Send(m);
                
            }
            catch(Exception ex) 
            { MessageBox.Show(Convert.ToString(ex)); }
        }

        private void btn_Done_Click(object sender, RoutedEventArgs e)
        {
            int i;
            bool res = int.TryParse(tb_KodForRestore.Text, out i);
            if (res == true)
            {
                if (i == KOD)
                { 
                    NavigationService.Navigate(new ChangePass(mail));
                }
            }
            else
            {
                MessageBox.Show("Введите четырехзначный код");
            }
        }
    }
}
