using Microsoft.EntityFrameworkCore;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.DataAccess.Core;

namespace TuvTurk.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfStationRepository : EfRepositoryBase<Station, TuvTurkDatabaseContext>, IStationDal
    {
        public EfStationRepository(TuvTurkDatabaseContext context) : base(context)
        {
        }
    }
}