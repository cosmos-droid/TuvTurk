using Microsoft.EntityFrameworkCore;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.DataAccess.Core;

namespace TuvTurk.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfEnumGroupTypeRepository : EfRepositoryBase<EnumGroupType, TuvTurkDatabaseContext>, IEnumGroupTypeDal
    {
        public EfEnumGroupTypeRepository(TuvTurkDatabaseContext context) : base(context)
        {
        }
    }
}