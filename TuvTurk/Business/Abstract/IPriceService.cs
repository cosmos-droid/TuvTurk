using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Abstract
{
    public interface IPriceService
    {
        IDataResult<Price> GetPriceById(long PriceId);
        IDataResult<IList<Price>> GetAllPrices();
        IDataResult<Price> GetPriceByEnumGroupTypeId(long enumGroupTypeId);

        IResult AddPrice(Price price);
        IResult UpdatePrice(Price price);
        IResult DeletePrice(Price price);
    }
}