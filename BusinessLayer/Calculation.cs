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


             if (sku.PromotionName=="CD")
            {
               

                var totalCountofSku1 = selectedSkuIdCount[sku.PromotionName[0].ToString()];                 
                var totalCountofSku2 = selectedSkuIdCount[sku.PromotionName[1].ToString()];
                if (totalCountofSku1 + totalCountofSku2 > 1)
                {
                        var costOfSku1 = skuIdCostMapping[sku.PromotionName[0].ToString()];
                        var costOfSku2 = skuIdCostMapping[sku.PromotionName[1].ToString()];

                      //  var isSku1PriceGreaterThanSku2 = costOfSku1 > costOfSku2 ? true : false;

                       // var difference = isSku1PriceGreaterThanSku2 ? totalCountofSku1 - totalCountofSku2 : totalCountofSku2 - totalCountofSku1;
                        actualCost = actualCost - (totalCountofSku1 * skuIdCostMapping[sku.PromotionName[0].ToString()]);
                        actualCost = actualCost - (totalCountofSku2 * skuIdCostMapping[sku.PromotionName[1].ToString()]);

                        var difference =  totalCountofSku1 - totalCountofSku2;

                        if (difference == 0)
                        {                            
                            costAfterApplyingPromotion = appliedPromotionCost * totalCountofSku1;
                            actualCost = actualCost + costAfterApplyingPromotion;

                        }
                        else if (difference > 0)
                        {

                            costAfterApplyingPromotion = appliedPromotionCost * totalCountofSku2;
                            costAfterApplyingPromotion = costAfterApplyingPromotion + (difference * costOfSku1);
                            actualCost = actualCost + costAfterApplyingPromotion;

                        }
                        else if (difference < 0)
                        {
                            costAfterApplyingPromotion = appliedPromotionCost * totalCountofSku1;
                            costAfterApplyingPromotion = costAfterApplyingPromotion + (difference * costOfSku2);
                            actualCost = actualCost + costAfterApplyingPromotion;
                        }

             }
            }
            else{
         
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
