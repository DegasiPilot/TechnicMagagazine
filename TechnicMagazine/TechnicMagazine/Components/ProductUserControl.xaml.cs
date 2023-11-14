using LanguageSchool.Components;
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
using TechnicMagazine.Pages;

namespace TechnicMagazine.Components
{
    /// <summary>
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        Product product;

        public ProductUserControl(Product product)
        {
            InitializeComponent();
            this.product = product;
            TitleTb.Text = product.Title;
            OcenkaTb.Text = $"{product.AvgOcenka: 0.00}";
            OtziviTb.Text = product.KolvoOtziv + " отзывов";
            CostTb.Text = $"{product.Cost: 0.00}";
            CostWithDiscountTb.Text = product.CostWithDiscount;
            CostTb.Visibility = product.CostVisiblity;
            ProductGrid.Background = product.DiscountBrush;
            if (App.IsAdmin == false)
            {
                RedactBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
            this.DataContext = product;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (product.Feedback != null)
            {
                MessageBox.Show("Удаление запрещено");
            }
            else
            {
                App.db.Product.Remove(product);
                App.db.SaveChanges();
                MyNavigation.BackPage();
            }
        }

        private void RedactBtn_Click(object sender, RoutedEventArgs e)
        {
            MyNavigation.NextPage(new PageComponent(new AddEditProductPage(product), "Редактировать продукт"));
        }

        private void KorzinaBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(ProductZakazUC prodZakUC in App.KorzinaWp.Children)
            {
                if(prodZakUC.product == product)
                {
                    prodZakUC.KolvoTb.Text = (prodZakUC.Kolvo + 1).ToString();
                    return;
                }
            }
            App.KorzinaWp.Children.Add(new ProductZakazUC(product));
            App.ProdListPage.CalculateItog();
        }
    }
}
