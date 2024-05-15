using System;
using System.Collections.Generic;
using System.Windows;
using HashPasswords;
using System.ComponentModel.DataAnnotations;
using Sotrudniki = Konuk_pr3.Model.Sotrudniki;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;
using User = Konuk_pr3.Model.User;
using Model1 = Konuk_pr3.Model.Model1;
using System.IO;
using NPOI.XWPF.UserModel;

namespace Konuk_pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для SotrudList.xaml
    /// </summary>
    public partial class SotrudList : System.Windows.Controls.Page
    {
        public Sotrudniki sotrudniki = new Sotrudniki();
        private string Role;
        public SotrudList()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();
                user.Login = tbLogin.Text;
                user.Parol = HashPassword.HashPassword1(tbparol.Text);

                sotrudniki.Imea = tbImia.Text;
                sotrudniki.Familia = tbFamilia.Text;
                sotrudniki.Otchestvo = tbOtchestvo.Text;
                sotrudniki.Adres = tbAdres.Text;
                sotrudniki.Telephon = tbNomerTelefona.Text;

                switch (cmbRol.Text)
                {
                    case "Директор":
                        sotrudniki.ID_dolzhnosti = 1;
                        Role = "Директор";
                        break;
                    case "Офисный работник":
                        sotrudniki.ID_dolzhnosti = 2;
                        Role = "Офисный работник";
                        break;
                    case "Вахтер":
                        sotrudniki.ID_dolzhnosti = 4;
                        Role = "Вахтер";
                        break;
                    case "Агент":
                        sotrudniki.ID_dolzhnosti = 3;
                        Role = "Агент";
                        break;
                }

                Helper helper = new Helper();

                helper.CreateUsers(user);
                
                sotrudniki.id_user = user.ID_user;

                var contextSotr = new ValidationContext(sotrudniki);
                var results = new List<ValidationResult>();

                if (!Validator.TryValidateObject(sotrudniki, contextSotr, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
                }
                else
                {
                    helper.CreateSotr(sotrudniki);
                    MessageBox.Show("Новый пользователь успешно создан!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании нового пользователя, возникла следующая ошибка " + ex);
            }
        }

        private void btnPrintWordDoc(object sender, RoutedEventArgs e)
        {
            if (sotrudniki != null)
            {
                DateTime currentDate = DateTime.Today;
                var items = new Dictionary<string, string>()
                {
                    {"<currentYear>", Convert.ToString(currentDate.Year)},
                    {"<currentDay>", Convert.ToString(currentDate.Day)},
                    {"<currentMounth>", Convert.ToString(currentDate.Month)},
                    {"<SotrFio>", (sotrudniki.Familia+" "+sotrudniki.Imea+" "+sotrudniki.Otchestvo).ToString() },
                    {"<Role>", Role.ToString()},
                    {"<DayStart>", currentDate.Day.ToString() },
                    {"<MounthStart>", currentDate.Month.ToString() },
                    {"<YearStart>", currentDate.Year.ToString() },
                    {"<Employee>", (sotrudniki.Familia+" "+sotrudniki.Imea+" "+sotrudniki.Otchestvo).ToString() },
                    {"<currentDate>", currentDate.Date.ToString() }
                };

                string filePath = @"D:\Программирование\Konuk_pr3\Konuk_pr3\Document\blank-trudovogo-dogovora.docx";

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    XWPFDocument doc = new XWPFDocument(fs);

                    foreach (var item in items)
                    {
                        foreach (var paragraph in doc.Paragraphs)
                        {
                            foreach (var run in paragraph.Runs)
                            {
                                if (run.Text.Contains(item.Key))
                                {
                                    run.SetText(run.Text.Replace(item.Key, item.Value), 0);
                                }
                            }
                        }
                    }

                    string newFilePath = @"C:\Users\User\Desktop\myDoc.docx";
                    using (FileStream fs2 = new FileStream(newFilePath, FileMode.Create, FileAccess.Write))
                    {
                        doc.Write(fs2);
                        MessageBox.Show("Документ сохранен!");
                    }

                }
            }
        }
    }
}
