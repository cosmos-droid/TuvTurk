
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Abstract
{
    public interface IStationService
    {
        IDataResult<Station> GetStationById(long StationId);
        IDataResult<IList<Station>> GetStationsByCityId(long cityId);
        IDataResult<IList<Station>> GetAllStations();

        IResult AddStation(Station station);
        IResult UpdateStation(Station station);
        IResult DeleteStation(Station station);


    }
}