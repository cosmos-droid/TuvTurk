using Microsoft.EntityFrameworkCore;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.DataAccess.Core;

namespace TuvTurk.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfCityRepository : EfRepositoryBase<City, TuvTurkDatabaseContext>, ICityDal
    {
        public EfCityRepository(TuvTurkDatabaseContext context) : base(context)
        {
        }
    }
}