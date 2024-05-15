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
using ConsoleApp2;
using System.IO;
using System.Windows.Markup;
using System.Diagnostics;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.Data.SqlClient;

namespace Konuk_pr3.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListSotrud.xaml
    /// </summary>
    public partial class ListSotrud : Page
    {
        List<Sotrudniki> sotrudniki;
        public ListSotrud()
        {
            InitializeComponent();
            sotrudniki = Model1.GetContext().Sotrudniki.ToList();
            LbSpisok.ItemsSource = sotrudniki;
            cmb_filter.SelectedIndex = 0;
        }

        private void btn_sort_Click(object sender, RoutedEventArgs e)
        {
            sotrudniki = Model1.GetContext().Sotrudniki.Where(t => t.Imea.Contains(txt_filter.Text) || t.Familia.Contains(txt_filter.Text)).ToList();

            if (cmb_filter.Text == "По возрастанию")
            {
               sotrudniki.OrderByDescending(t => t.Imea);
            }
            if (cmb_filter.Text == "По убыванию")
            {
               sotrudniki.OrderBy(t => t.Imea);
            }
            LbSpisok.ItemsSource = sotrudniki;
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            sotrudniki = Model1.GetContext().Sotrudniki.ToList();
            LbSpisok.ItemsSource = sotrudniki;
            txt_filter.Clear();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SotrudList());
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int ind = LbSpisok.SelectedIndex;
            int kod_sotrudnika = sotrudniki[ind].ID_sotrudnika;
            CurrentUser currentUser = new CurrentUser(kod_sotrudnika);
            this.NavigationService.Navigate(currentUser);
        }

        private void Print_btn_Click(object sender, RoutedEventArgs e)
        {

            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                IDocumentPaginatorSource idp = flowdoc;
                pd.PrintDocument(idp.DocumentPaginator, Title);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                using (Model1 context = new Model1())
                {
                    List<Sotrudniki> sotrudnikis = context.Sotrudniki.ToList();
    
                    XSSFWorkbook workbook = new XSSFWorkbook();
                    ISheet sheet = workbook.CreateSheet("Sotrudniki");
    
                    int i = 0;
                    foreach (var sotrudniki in sotrudnikis)
                        {
                            IRow row = sheet.CreateRow(i);

                            row.CreateCell(0).SetCellValue(sotrudniki.ID_sotrudnika.ToString());
                            row.CreateCell(1).SetCellValue(sotrudniki.Imea);
                            row.CreateCell(2).SetCellValue(sotrudniki.Familia);
                            row.CreateCell(5).SetCellValue(sotrudniki.Otchestvo);
                            row.CreateCell(3).SetCellValue(sotrudniki.Adres);
                            row.CreateCell(4).SetCellValue(sotrudniki.Telephon);
        
                            i++;
                        }
                    using (FileStream file = new FileStream(@"C:\Users\User\Desktop\myXSL.xlsx", FileMode.Create))
                        {
                            workbook.Write(file);
                            MessageBox.Show("Файл создан!");
                        }
                }
        }
    }
}
