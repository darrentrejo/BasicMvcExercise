using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgrammingExercise.WebUI.Models;
using System.Web.Mvc;

namespace ProgrammingExercise.WebUI.Binders
{
    public class ShoppingBasketModelBinder : IModelBinder
    {
        private const string sessionKey = "ShoppingBaskets";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext modelBindingContext)
        {
            // get the Shoppping Baskets from the session
            List<ShoppingBasketModel> ShoppingBaskets = (List<ShoppingBasketModel>)controllerContext.HttpContext.Session[sessionKey];

            // create the List of Shopping Baskets if there wasn't one in the session data
            if (ShoppingBaskets == null)
            {
                ShoppingBaskets = new List<ShoppingBasketModel>();
                controllerContext.HttpContext.Session[sessionKey] = ShoppingBaskets;
            }

            // return the list of Shopping Baskets
            return ShoppingBaskets;
        }
    }
}