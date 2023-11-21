using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicMagazine.Components
{
    partial class Product_Zakaz
    {
        public string ProductName
        {
            get
            {
                return App.db.Product.First(x => x.Id == ProductId).Title;
            }
        }
    }
}
