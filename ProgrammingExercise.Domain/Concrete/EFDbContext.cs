using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingExercise.Domain.Entities;
using System.Data.Entity;

namespace ProgrammingExercise.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<ShoppingBasket> ShoppingBaskets { get; set; }
        public DbSet <LineItem> LineItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SalesTaxCode> SalesTaxCodes { get; set; }
        public DbSet<ImportDutyCode> ImportDutyCodes { get; set; }
    }
}
