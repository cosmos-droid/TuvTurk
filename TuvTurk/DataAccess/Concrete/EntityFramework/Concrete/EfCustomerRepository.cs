using Microsoft.EntityFrameworkCore;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.DataAccess.Core;

namespace TuvTurk.DataAccess.Concrete.EntityFramework.Concrete
{
    public class EfCustomerRepository : EfRepositoryBase<Customer, TuvTurkDatabaseContext>, ICustomerDal
    {
        public EfCustomerRepository(TuvTurkDatabaseContext context) : base(context)
        {
        }
    }
}