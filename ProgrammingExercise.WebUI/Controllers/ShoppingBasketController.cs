using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgrammingExercise.Domain.Abstract;
using ProgrammingExercise.Domain.Entities;
using ProgrammingExercise.WebUI.Models;

namespace ProgrammingExercise.WebUI.Controllers
{
    public class ShoppingBasketController : Controller
    {
        private IShoppingBasketRepository repository;

        public ShoppingBasketController(IShoppingBasketRepository shoppingBasketRepository)
        {
            this.repository = shoppingBasketRepository;
        }

        public ViewResult ListAllShoppingBaskets()
        {
            var lineItemsGroupedByShoppingBasketID = from lineItem in this.repository.LineItems
                                                     group lineItem by lineItem.ShoppingBasketID into lineItemGroup
                                                     select lineItemGroup.Key;
            int[] shoppingBasketIDsToDisplay = lineItemsGroupedByShoppingBasketID.ToArray();

            var lineItemsForTheseShoppingBaskets = from lineItem in this.repository.LineItems
                                                   where shoppingBasketIDsToDisplay.Contains(lineItem.ShoppingBasketID)
                                                   select new LineItemModel
                                                   {
                                                       ShoppingBasketID = lineItem.ShoppingBasketID,
                                                       Quantity = lineItem.Quantity,
                                                       Name = lineItem.Name,
                                                       Price = lineItem.Price,
                                                       SalesTaxRate = lineItem.SalesTaxRate,
                                                       ImportDutyRate = lineItem.ImportDutyRate
                                                   };
            List<LineItemModel> lineItemModelsToDisplay = lineItemsForTheseShoppingBaskets.ToList<LineItemModel>();

            List<ShoppingBasketModel> ShoppingBaskets = new List<ShoppingBasketModel>();

            for (int i = 0; i < shoppingBasketIDsToDisplay.Length; i++)
            {
                int tempShoppingBasketID = shoppingBasketIDsToDisplay[i];
                List<LineItemModel> tempList = new List<LineItemModel>();
                foreach (LineItemModel lim in lineItemModelsToDisplay)
                {
                    if (lim.ShoppingBasketID == tempShoppingBasketID)
                    {
                        tempList.Add(lim);
                    }
                }
                ShoppingBasketModel addThisShoppingBasketModel = new ShoppingBasketModel(tempShoppingBasketID, tempList);
                ShoppingBaskets.Add(addThisShoppingBasketModel);
            }

            Session["ShoppingBaskets"] = ShoppingBaskets;
            return View(new ShoppingBasketOutputViewModel
            {
                ShoppingBaskets = ShoppingBaskets,
            });
        }

        public ViewResult OutputTotals(List<ShoppingBasketModel> ShoppingBaskets)
        {
            return View(new ShoppingBasketOutputViewModel
            {
                ShoppingBaskets = ShoppingBaskets,
            });
        }
    }
}
