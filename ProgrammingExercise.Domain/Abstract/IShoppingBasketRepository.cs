using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingExercise.Domain.Entities;

namespace ProgrammingExercise.Domain.Abstract
{
    public interface IShoppingBasketRepository
    {
        IQueryable<LineItemModel> LineItems { get; }
    }
}
