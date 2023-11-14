using LanguageSchool.Components;
using System;
using System.Collections.Generic;
using System.IO;
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
using TechnicMagazine.Components;
using TechnicMagazine.Pages;

namespace TechnicMagazine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyNavigation.mainWindow = this;
            //var path = @"C:\Users\222119\Downloads\";
            //foreach (var item in App.db.Product.ToArray())
            //{
            //    var fullPath = path + item.MainImagePath.Trim();
            //    var imageByte = File.ReadAllBytes(fullPath);
            //    item.MainImage = imageByte;
            //}
            MyNavigation.NextPage(new PageComponent(new ProductListPage(), "Список продуктов"));
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.IsAdmin)
            {
                App.IsAdmin = false;
                AdminBtnText.Text = "Вкл. режим администратора";
                MyNavigation.ClearStory();
                MyNavigation.NextPage(new PageComponent(new ProductListPage(), "Список продуктов"));
                
            }
            else
            {
                if (AdminPb.Password == "0000")
                {
                    App.IsAdmin = true;
                    AdminBtnText.Text = "Выкл. режим администратора";
                    AdminPb.Clear();
                    MyNavigation.ClearStory();
                    MyNavigation.NextPage(new PageComponent(new ProductListPage(), "Список продуктов"));
                }
                else
                {
                    MessageBox.Show("Неправильный пароль!");
                }
            }
            SpisokBtn.Visibility = App.IsAdmin ? Visibility.Visible : Visibility.Hidden;
        }

        private void SpisokBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
