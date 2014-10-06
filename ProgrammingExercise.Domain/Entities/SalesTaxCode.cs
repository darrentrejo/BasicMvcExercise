using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProgrammingExercise.Domain.Entities
{
    public class SalesTaxCode
    {
        [Key]
        public string SalesTaxID { get; set; }
        public decimal Rate { get; set; }
    }
}
