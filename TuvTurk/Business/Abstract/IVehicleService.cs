using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Abstract
{
    public interface IvehicleService
    {
        IDataResult<Vehicle> GetVehicleById(long vehicleId);
        IDataResult<IList<Vehicle>> GetAllVehicles();

        IDataResult<EnumGroupType> CheckVehicleTypeByPlateNo(string plateNo);

        IDataResult<bool> DoesPlateExist(string plateNo);
        IDataResult<bool> PlateRuhsatCheck(string plateNo, string vehicleSerialNumberNo);
        IResult AddVehicle(Vehicle vehicle);
        IResult UpdateVehicle(Vehicle vehicle);
        IResult DeleteVehicle(Vehicle vehicle);

        

        
    }
}