using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ProgrammingExercise.Domain.Entities;

namespace ProgrammingExercise.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void canCalculateSalesTax()
        {
            //arrange
            LineItemModel lim = new LineItemModel();
            lim.Quantity = 1;
            lim.Price = 47.5M;
            lim.ImportDutyRate = 5.0M;
            lim.SalesTaxRate = 10.0M;

            //assert
            Assert.AreEqual(7.15M, lim.calculateTaxes());
        }
    }
}
