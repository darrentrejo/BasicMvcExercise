using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingExercise.Domain.Abstract;
using ProgrammingExercise.Domain.Entities;

namespace ProgrammingExercise.Domain.Concrete
{
    public class EFShoppingBasketRepository : IShoppingBasketRepository
    {
        private EFDbContext context = new EFDbContext();

        private IEnumerable<LineItemModel> getLineItems()
        {
            var lineItems = from li in context.LineItems
                            join prod in context.Products on li.ProductID equals prod.ProductID
                            join sb in context.ShoppingBaskets on li.ShoppingBasketID equals sb.ShoppingBasketID
                            join category in context.Categories on prod.CategoryID equals category.CategoryID
                            join salesTax in context.SalesTaxCodes on category.SalesTaxID equals salesTax.SalesTaxID
                            join importDuty in context.ImportDutyCodes on prod.ImportDutyID equals importDuty.ImportDutyID
                            select new LineItemModel
                            {
                                ShoppingBasketID = li.ShoppingBasketID,
                                Quantity = li.Quantity,
                                Name = prod.Name,
                                Price = prod.Price,
                                ImportDutyRate = importDuty.Rate,
                                SalesTaxRate = salesTax.Rate
                            };
            return lineItems.ToList<LineItemModel>();
        }
        
        public IQueryable<LineItemModel> LineItems
        {
            get { return getLineItems().AsQueryable(); }
        }
    }
}
