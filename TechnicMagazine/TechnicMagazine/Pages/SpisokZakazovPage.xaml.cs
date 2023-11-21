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
    /// Логика взаимодействия для SpisokZakazovPage.xaml
    /// </summary>
    public partial class SpisokZakazovPage : Page
    {
        public SpisokZakazovPage()
        {
            InitializeComponent();
            foreach(Zakaz zakaz in App.db.Zakaz.OrderBy(x => x.Status))
            {
                ZakazWp.Children.Add(new ZakazUserControl(zakaz));
            }
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ZakazWp.Children.Clear();
            List<Zakaz> zakazes = App.db.Zakaz.ToList();
            if (SortCb.SelectedIndex == 0)
            {
                zakazes = zakazes.OrderBy(x =>x.Status).ToList();
            }
            else
            {
                zakazes = zakazes.OrderByDescending(x => x.Status).ToList();
            }
        }
    }
}
