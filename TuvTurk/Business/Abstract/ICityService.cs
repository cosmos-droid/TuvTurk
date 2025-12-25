using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Abstract
{
    public interface ICityService
    {
        IDataResult<City> GetCityById(long CityId);
        IDataResult<IList<City>> GetAllCities();

        IResult AddCity(City city);
        IResult UpdateCity(City city);
        IResult DeleteCity(City city);


    }
}