using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Concrete
{
    public class StationManager : IStationService
    {
        private readonly IStationDal _stationDal;

        public StationManager(IStationDal stationDal)
        {
            _stationDal = stationDal;
        }

        public IResult AddStation(Station station)
        {
            try
            {
                _stationDal.Add(station);
                return new SuccessResult(message: Messages.StationAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }

        public IResult DeleteStation(Station station)
        {
            try
            {
                _stationDal.Delete(station);
                return new SuccessResult(message: Messages.StationDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }



        public IDataResult<IList<Station>> GetAllStations()
        {
            try
            {
                return new SuccessDataResult<IList<Station>>(_stationDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Station>>(message: ex.Message);
            }
        }

        public IDataResult<Station> GetStationById(long StationId)
        {
            try
            {
                return new SuccessDataResult<Station>(_stationDal.Get(s => s.StationId == StationId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Station>(message: ex.Message);
            }
        }

        public IResult UpdateStation(Station station)
        {
            try
            {
                _stationDal.Update(station);
                return new SuccessResult(message: Messages.StationUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }

}