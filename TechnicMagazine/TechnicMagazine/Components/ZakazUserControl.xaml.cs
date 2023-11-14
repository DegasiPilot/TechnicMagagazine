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
    /// Логика взаимодействия для ZakazUserControl.xaml
    /// </summary>
    public partial class ZakazUserControl : UserControl
    {
        Zakaz zakaz;

        public ZakazUserControl(Zakaz _zakaz)
        {
            InitializeComponent();
            zakaz = _zakaz;
            ZakazNumberTb.Text = $"Номер заказа {zakaz.Id}";
            ZakazDateTb.Text = $"Дата заказа {zakaz.ZakazDate}";
            StatusCb.IsChecked = zakaz.Status;
        }

        private void SetUpGridView()
        {

        }
    }
}
