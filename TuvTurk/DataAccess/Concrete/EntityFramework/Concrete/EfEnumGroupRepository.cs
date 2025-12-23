using Microsoft.EntityFrameworkCore;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.DataAccess.Core;

namespace TuvTurk.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfEnumGroupRepository : EfRepositoryBase<EnumGroup, TuvTurkDatabaseContext>, IEnumGroupDal
    {
        public EfEnumGroupRepository(TuvTurkDatabaseContext context) : base(context)
        {
        }
    }
}