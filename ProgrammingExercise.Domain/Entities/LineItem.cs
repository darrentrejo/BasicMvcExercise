using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercise.Domain.Entities
{
    public class LineItem
    {
        public int LineItemID { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public int ShoppingBasketID { get; set; }
    }
}
