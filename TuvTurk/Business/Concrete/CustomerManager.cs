using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }



        public IResult AddCustomer(Customer customer)
        {
            try
            {
                _customerDal.Add(customer);
                return new SuccessResult(message: Messages.CustomerAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }


        public IResult DeleteCustomer(Customer customer)
        {
            try
            {
                _customerDal.Delete(customer);
                return new SuccessResult(message: Messages.CustomerDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<Customer>> GetAllCustomers()
        {
            try
            {
                return new SuccessDataResult<IList<Customer>>(_customerDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Customer>>(message: ex.Message);
            }
        }

        public IDataResult<Customer> GetCustomerById(long customerId)
        {
            try
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Customer>(message: ex.Message);
            }
        }

        public IResult UpdateCustomer(Customer customer)
        {
            try
            {
                _customerDal.Update(customer);
                return new SuccessResult(message: Messages.CustomerUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }



}