using Microsoft.AspNetCore.Mvc;
using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;
        private readonly IStationDal _stationDal;

        public CityManager(ICityDal cityDal, IStationDal stationDal)
        {
            _cityDal = cityDal;
            _stationDal = stationDal;
        }

        public IResult AddCity(City city)
        {
            try
            {
                _cityDal.Add(city);
                return new SuccessResult(message: Messages.CityAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }

        public IResult DeleteCity(City city)
        {
            try
            {
                _cityDal.Delete(city);
                return new SuccessResult(message: Messages.CityDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }

        public IDataResult<IList<City>> GetAllCities()
        {
            try
            {
                return new SuccessDataResult<IList<City>>(_cityDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<City>>(message: ex.Message);
            }
            
        }

        public IDataResult<IList<City>> GetAllCitiesWithStaion()
        {
            try
            {
                List<long> cityIds = _stationDal.GetAll().Select(q => q.CityId).Distinct().ToList();
                IList<City> cities = new List<City>();
                
                foreach(long cityId in cityIds)
                {
                    City city = GetCityById(cityId).Data;    
                    cities.Add(city);

                }

                return new SuccessDataResult<IList<City>>(cities);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<City>>(message: ex.Message);
            }            

        }

        public IDataResult<City> GetCityById(long CityId)
        {
            try
            {
                return new SuccessDataResult<City>(_cityDal.Get(c => c.CityId == CityId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<City>(message: ex.Message);
            }
        }

        public IResult UpdateCity(City city)
        {
            try
            {
                _cityDal.Update(city);
                return new SuccessResult(message: Messages.CityUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }

}