using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;


namespace TuvTUrk.Business.Concrete
{
    public class PriceManager : IPriceService
    {
        private readonly IPriceDal _priceDal;
        public PriceManager(IPriceDal priceDal)
        {
            _priceDal = priceDal;
        }

        public IDataResult<Price> GetPriceById(long priceId)
        {
            try
            {
                return new SuccessDataResult<Price>(_priceDal.Get(q => q.PriceId == priceId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Price>(ex.Message);
            }
        }


        public IDataResult<IList<Price>> GetAllPrices()
        {
            try
            {
                return new SuccessDataResult<IList<Price>>(_priceDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Price>>(message: ex.Message);
            }
        }

        public IDataResult<Price> GetPriceByEnumGroupTypeId(long enumGroupTypeId)
        {
            try
            {
                return new SuccessDataResult<Price>(_priceDal.Get(q => q.EnumGroupTypeId == enumGroupTypeId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Price>(ex.Message);
            }
        }

        public IDataResult<double> GetTotalPrice(long vehicleTypeId, long inspectionTypeId)
        {
            try
            {
                double vehiclePrice = GetPriceByEnumGroupTypeId(vehicleTypeId).Data.ServicePrice;
                double inspectionPrice = GetPriceByEnumGroupTypeId(inspectionTypeId).Data.ServicePrice;
                double totalPrice = vehiclePrice + inspectionPrice;
                return new SuccessDataResult<double>(totalPrice);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<double>(message: ex.Message);
            }


        }


        public IResult AddPrice(Price price)
        {
            try
            {
                _priceDal.Add(price);
                return new SuccessResult(message: Messages.PriceAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);

            }
        }

        public IResult DeletePrice(Price price)
        {
            try
            {
                _priceDal.Delete(price);
                return new SuccessResult(message: Messages.PriceDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }


        public IResult UpdatePrice(Price price)
        {
            try
            {
                _priceDal.Update(price);
                return new SuccessResult(message: Messages.PriceUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }


    }
}