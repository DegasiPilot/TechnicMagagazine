using LanguageSchool.Components;
using Microsoft.Win32;
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

namespace TechnicMagazine.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        Product product;
        public AddEditProductPage(Product _product)
        {
            InitializeComponent();
            product = _product;
            DataContext = product;
            //RefreshPhoto();
            //PhotoUserContol.parentScript = this;
        }

        private void EditImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*jpg|*jpg|*jpeg|*jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                product.MainImage = File.ReadAllBytes(openFile.FileName);
                MainImage.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (App.db.Product.Any(x => x.Title == product.Title && (product.Id == 0 || x.Id != product.Id)))
            {
                errors.AppendLine("Такой продукт уже существует");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                if (product.Id == 0)
                {
                    App.db.Product.Add(product);
                }
                App.db.SaveChanges();
                MyNavigation.BackPage();
            }
        }

        private void DiscountTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
        }
    }
}