using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TechnicMagazine.Components;
using TechnicMagazine.Pages;

namespace TechnicMagazine
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static HardwareShopEntities db = new HardwareShopEntities();
        public static bool IsAdmin = false;
        public static ProductListPage ProdListPage;
        public static WrapPanel KorzinaWp;
    }
}
