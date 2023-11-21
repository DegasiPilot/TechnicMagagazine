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
using TechnicMagazine.Components;

namespace TechnicMagazine.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public Zakaz zakaz;

        public ProductListPage()
        {
            InitializeComponent();
            App.ProdListPage = this;
            App.KorzinaWp = KorzinaWp;
            if (App.IsAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            Refresh_Filter(null, null);
            zakaz = new Zakaz();
        }

        private void Refresh_Filter(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> products = App.db.Product;

            switch (DiscountFilterCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    products = products.Where(x => x.Discount >= 0 && x.Discount < 0.05);
                    break;
                case 2:
                    products = products.Where(x => x.Discount >= 0.05 && x.Discount < 0.15);
                    break;
                case 3:
                    products = products.Where(x => x.Discount >= 0.15 && x.Discount < 0.30);
                    break;
                case 4:
                    products = products.Where(x => x.Discount >= 0.30 && x.Discount < 0.70);
                    break;
                case 5:
                    products = products.Where(x => x.Discount >= 0.70 && x.Discount < 0.100);
                    break;
            }

            string searchText = SearchTb.Text.ToLower();
            if (searchText != "")
            {
                products = products.Where(x => x.Title.ToLower().Contains(searchText) || x.Description.ToLower().Contains(searchText));
            }

            switch (SortCb.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    products = products.OrderBy(x => x.CostWithDiscount);
                    break;
                case 2:
                    products = products.OrderByDescending(x => x.CostWithDiscount);
                    break;
            }

            ProductWrapPanel.Children.Clear();
            foreach (var product in products)
            {
                ProductWrapPanel.Children.Add(
                    new ProductUserControl(product)
                );
            }
            KolvoProductovTb.Text = products.Count() + " из " + App.db.Product.Count();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            MyNavigation.NextPage(new PageComponent(new AddEditProductPage(new Product()), "Добавить продукт"));
        }

        private void ZakazBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckZakaz())
                return;

            zakaz.ZakazDate = DateTime.Now;
            zakaz.Status = false;
            zakaz = App.db.Zakaz.Add(zakaz);

            Product_Zakaz prodZak;
            foreach(ProductZakazUC ProdZakUC in KorzinaWp.Children)
            {
                prodZak = new Product_Zakaz();
                prodZak.ZakazId = zakaz.Id;
                prodZak.ProductId = ProdZakUC.product.Id;
                prodZak.Kolvo = ProdZakUC.Kolvo;
                App.db.Product_Zakaz.Add(prodZak);
            }
            App.db.SaveChanges();
            MessageBox.Show("Заказ успешно оформлен!");
            ClearZakaz();
        }

        private bool CheckZakaz()
        {
            if(KorzinaWp.Children.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы 1 товар!");
                return false;
            }

            foreach (ProductZakazUC ProdZakUC in KorzinaWp.Children)
            {
                if (ProdZakUC.Kolvo == 0)
                {
                    MessageBox.Show("Введите количество для всех товаров!");
                    return false;
                }
            }
            return true;
        }

        private void ClearZakaz()
        {
            zakaz = new Zakaz();
            KorzinaWp.Children.Clear();
        }

        public void CalculateItog()
        {   
            double itog = 0;
            foreach (ProductZakazUC ProdZakUC in KorzinaWp.Children)
            {
                    itog += ProdZakUC.Summ;
            }
            ItogTb.Text = $"Итог: {itog}";
        }
    }
}