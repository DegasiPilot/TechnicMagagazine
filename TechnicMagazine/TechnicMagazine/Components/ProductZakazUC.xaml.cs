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

namespace TechnicMagazine.Components
{
    /// <summary>
    /// Логика взаимодействия для ProductZakazUC.xaml
    /// </summary>
    public partial class ProductZakazUC : UserControl
    {
        public Product product;
        public int Kolvo;
        public double Summ;

        public ProductZakazUC(Product _product)
        {
            InitializeComponent();
            product = _product;
            DataContext = product;
            CostTb.Text = product.FinalCost.ToString();
            Kolvo = 1;
            KolvoTb.Text = Kolvo.ToString();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            App.KorzinaWp.Children.Remove(this);
            App.ProdListPage.CalculateItog();
        }

        private void KolvoTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(KolvoTb.Text, out Kolvo) && Kolvo != 0)
            {
                Summ = Kolvo * Convert.ToDouble(CostTb.Text);
                SummTb.Text = Summ.ToString();
            }
            else
            {
                Summ = 0;
                SummTb.Text = "";
            }
            App.ProdListPage.CalculateItog();
        }

        private void KolvoTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
                e.Handled = true;
        }
    }
}
