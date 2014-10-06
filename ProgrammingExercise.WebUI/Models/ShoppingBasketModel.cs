using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingExercise.Domain.Entities;

namespace ProgrammingExercise.WebUI.Models
{
    public class ShoppingBasketModel
    {
        public int ShoppingBasketID { get; set; }
        public List<LineItemModel> LineItems { get; set; }
        public decimal SubTotal { get; private set; }
        public decimal SalesTaxes { get; private set; }
        public decimal ImportDuty { get; private set; }

        public ShoppingBasketModel()
        {

        }

        public ShoppingBasketModel(int ShoppingBasketID, List<LineItemModel> LineItems)
        {
            this.ShoppingBasketID = ShoppingBasketID;
            this.LineItems = LineItems;
            calculateSubtotal();
            calculateSalesTaxes();
        }

        private void calculateSubtotal()
        {
            decimal subTotal = 0.0M;
            foreach (LineItemModel lineItem in LineItems)
            {
                subTotal += lineItem.Quantity * lineItem.Price;
            }
            this.SubTotal += subTotal;
        }

        private void calculateSalesTaxes()
        {
            decimal salesTaxes = 0.0M;
            foreach (LineItemModel lineItemModel in this.LineItems)
            {
                salesTaxes += lineItemModel.calculateTaxes();
            }
            this.SalesTaxes = salesTaxes;
        }

        public decimal calculateGrandTotal()
        {
            return this.SubTotal + this.SalesTaxes + this.ImportDuty;
        }
    }
}