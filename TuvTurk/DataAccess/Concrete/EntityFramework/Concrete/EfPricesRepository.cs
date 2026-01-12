using Microsoft.EntityFrameworkCore;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.DataAccess.Core;

namespace TuvTurk.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfPricesRepository : EfRepositoryBase<Price, TuvTurkDatabaseContext>, IPriceDal
    {
        public EfPricesRepository(TuvTurkDatabaseContext context) : base(context)
        {
        }
    }
}