using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TechnicMagazine.Components
{
    public partial class Product
    {
        public string CostWithDiscount
        {
            get 
            {
                if (Discount == 0)
                    return $"{Cost : 0.00} р.";
                else
                    return $"{(Cost - Cost * (decimal)Discount) : 0.00} р.";
            }
        }

        public double FinalCost
        {
            get
            {
                return Convert.ToDouble(Cost - Cost * (decimal)Discount);
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

        public double AvgOcenka
        {
            get
            {
                var feedBacks = App.db.Feedback.Where(x => x.ProductId == Id).ToList();
                if (feedBacks.Count == 0)
                    return 0;
                else
                    return feedBacks.Average(x => x.Evaluation);
            }
        }

        public int KolvoOtziv
        {
            get
            {
                return App.db.Feedback.Where(x => x.ProductId == Id).Count();
            }
        }

        public Brush DiscountBrush
        {
            get
            {
                if (Discount != 0)
                {
                    return Brushes.PaleGreen;
                }
                else
                    return Brushes.White;
            }
        }
    }
}