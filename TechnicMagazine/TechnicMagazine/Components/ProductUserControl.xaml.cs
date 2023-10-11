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
    /// Логика взаимодействия для ProductUserControl.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public ProductUserControl(Image image, string Title, string Evaluation, string KolvoOtziv,string cost, string CostWithDiscount, Visibility costTbVisibility)
        {
            InitializeComponent();
            ProductImage = image;
            TitleTb.Text = Title;
            OcenkaTb.Text = Evaluation;
            OtziviTb.Text = KolvoOtziv;
            CostTb.Text = cost;
            CostWithDiscountTb.Text = CostWithDiscount;
            CostTb.Visibility = costTbVisibility;
        }
    }
}
