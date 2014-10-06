using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercise.Domain.Entities
{
    public class LineItemModel
    {
        public int ShoppingBasketID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal SalesTaxRate { get; set; }
        public decimal ImportDutyRate { get; set; }
        public int Quantity { get; set; }

        public decimal calculateTaxes()
        {
            decimal salesTax = this.Quantity * this.Price * (this.SalesTaxRate / 100);
            decimal importDuty = this.Quantity * this.Price * (this.ImportDutyRate / 100);
            decimal totalTaxRate = this.SalesTaxRate + this.ImportDutyRate;
            decimal totalTaxRateAsPercent = totalTaxRate / 100;
            decimal input = (this.Quantity * this.Price) * totalTaxRateAsPercent;
            return Math.Ceiling(input / .05M) * .05M;
            }
    }
}
