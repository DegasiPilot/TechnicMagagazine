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
            //var path = @"C:\Users\222119\Downloads\Задание магазин техники\";
            //foreach (var item in App.db.Product.ToArray())
            //{
            //    var fullPath = path + item.MainImagePath.Trim();
            //    var imageByte = File.ReadAllBytes(fullPath);
            //    item.MainImage = imageByte;
            //}
            Random random = new Random();
            var products = App.db.Product.ToList();
            foreach (var product in products)
            {
                ProductWrapPanel.Children.Add(
                    new ProductUserControl(
                    new Image(),
                    product.Title,
                    (4 + random.NextDouble()).ToString("0"),
                    random.Next(1, 10) + " отзывов",
                    product.Cost.ToString(),
                    product.CostWithDiscount.ToString(),
                    product.CostVisiblity
                    )
                );
            }
        }
    }
}
