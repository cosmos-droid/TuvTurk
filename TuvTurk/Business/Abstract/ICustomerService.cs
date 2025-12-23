
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<Customer> GetCustomerById(long CustomerId);
        IDataResult<IList<Customer>> GetAllCustomers();

        IResult AddCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);


    }
}