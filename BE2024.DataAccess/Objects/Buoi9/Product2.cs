using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE2024.DataAccess.Objects
{
    public class Product2
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public double DiscountedPrice {  get; set; }
        public double CalculatorDiscount()
        {
            if (Discount == 0)
            {
                if (Price > 100000)
                    return Price * 5 / 100;
                if (Price > 10000)
                    return Price * 1 / 100;
            }
            else
            {
                // Discount == 1
                if (Price > 100000)
                    return 1000;
                if (Price > 10000)
                    return 5000;
            }

            return 0;
        }
    }
}
