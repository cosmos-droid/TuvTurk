using Microsoft.EntityFrameworkCore;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.DataAccess.Core;

namespace TuvTurk.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfVehicleRepository : EfRepositoryBase<Vehicle, TuvTurkDatabaseContext>, IVehicleDal
    {
        public EfVehicleRepository(TuvTurkDatabaseContext context) : base(context)
        {
        }
    }
}