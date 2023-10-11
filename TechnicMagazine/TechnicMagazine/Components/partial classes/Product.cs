using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TechnicMagazine.Components
{
    public partial class Product
    {
        public string CostWithDiscount
        {
            get 
            {
                if (Discount == 0)
                    return $"{Cost} р.";
                else
                    return $"{Cost - Cost * (decimal)Discount} р.";
            }
        }

        public Visibility CostVisiblity
        {
            get
            {
                if (Discount == 0)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public string TextDiscount
        {
            get
            {
                if (Discount == 0)
                    return null;
                else
                    return $"* скидка {Discount * 100}%";
            }
        }
    }
}
