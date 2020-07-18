using PromotionEngine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Calculation
    {
        public string GetCost(Sku sku)
        {
            float cost = 34.56f;

            return Convert.ToString(cost);
        }
    }
}
