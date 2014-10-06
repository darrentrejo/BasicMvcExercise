using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingExercise.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImportDutyID { get; set; }
        public int CategoryID { get; set; }
    }
}
