using TuvTurk.DataAccess.Abstract;
using TuvTurk.DataAccess.Core;
using TuvTurk.Entities.Concrete;

namespace TuvTurk.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfSlotRepository : EfRepositoryBase<Slots, TuvTurkDatabaseContext>, ISlotDal
    {
    }
}