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

           var selectedSkuIdCount = new Dictionary<string,int>();
          var skuIdCostMapping =  GetSkuIdCostMapping();

          var promotionTypes = GetPromotionTypes();

          var appliedPromotionCost = promotionTypes[sku.PromotionName];
          var actualCost = 0.0f;
          var skuIds =  sku.SkuIds.Split(',');

          var costAfterApplyingPromotion = 0.0f;
          foreach (var skuId in skuIds)
          {
              actualCost = actualCost + skuIdCostMapping[skuId];

              if (selectedSkuIdCount.Keys.Contains(skuId))
              {
                  selectedSkuIdCount[skuId] = selectedSkuIdCount[skuId] + 1;
              }
              else
              {
                  selectedSkuIdCount.Add(skuId, 1);
              }

          }


            
         
              var totalCountofthisSku = selectedSkuIdCount[sku.PromotionName[0].ToString()];              
              var numberOfTimes = sku.PromotionName.Length;
             
             

              if(totalCountofthisSku>numberOfTimes)
              {
                  actualCost = actualCost - (totalCountofthisSku * skuIdCostMapping[sku.PromotionName[0].ToString()]);
                  var repeatition = totalCountofthisSku / numberOfTimes;
                  var remaining = totalCountofthisSku - (repeatition * numberOfTimes);
                 
                  costAfterApplyingPromotion = skuIdCostMapping[sku.PromotionName[0].ToString()] * remaining;
                  costAfterApplyingPromotion = costAfterApplyingPromotion +( appliedPromotionCost * repeatition);
                  actualCost = actualCost + costAfterApplyingPromotion;
              }








              float cost = actualCost;

            return Convert.ToString(actualCost);
        }

        private Dictionary<string, float> GetPromotionTypes()
        {
            Dictionary<string, float> promotionTypes = new Dictionary<string, float>();
            promotionTypes.Add("AAA", 130);
            promotionTypes.Add("CD", 30);            
            
            return promotionTypes;
        }



        private Dictionary<string, float> GetSkuIdCostMapping()
        {
            Dictionary<string, float> skuIdCostMapping = new Dictionary<string, float>();
            skuIdCostMapping.Add("A", 50);
            skuIdCostMapping.Add("B", 30);
            skuIdCostMapping.Add("C", 20);
            skuIdCostMapping.Add("D", 15);
            return skuIdCostMapping;
        }

        
    }


    
}
