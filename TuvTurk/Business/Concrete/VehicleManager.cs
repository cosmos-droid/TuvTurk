using Microsoft.AspNetCore.Mvc;
using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;


namespace TuvTurk.Business.Concrete
{
    public class VehicleManager : IvehicleService
    {

        private readonly IVehicleDal _vehicleDal;
        private readonly IEnumGroupTypeDal _enumGroupTypeDal;

        public VehicleManager(IVehicleDal vehicleDal, IEnumGroupTypeDal enumGroupTypeDal)
        {
            _vehicleDal = vehicleDal;
            _enumGroupTypeDal = enumGroupTypeDal;
        }

        public IResult AddVehicle(Vehicle vehicle)
        {
            try
            {
                _vehicleDal.Add(vehicle);
                return new SuccessResult(message: Messages.VehicleAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }        
        }

        public IResult DeleteVehicle(Vehicle vehicle)
        {
            try
            {
                _vehicleDal.Delete(vehicle);
                return new SuccessResult(message: Messages.VehicleDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }      
        }

        public IResult UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                _vehicleDal.Update(vehicle);
                return new SuccessResult(message: Messages.VehicleDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }            
        }

        public IDataResult<IList<Vehicle>> GetAllVehicles()
        {
            try
            {
                return new SuccessDataResult<IList<Vehicle>>(_vehicleDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Vehicle>>(message: ex.Message);
            }

        }

        public IDataResult<Vehicle> GetVehicleById(long vehicleId)
        {
            try
            {
                return new SuccessDataResult<Vehicle>(_vehicleDal.Get(s => s.VehicleId == vehicleId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Vehicle>(message: ex.Message);
            }
            
        }

        public IDataResult<bool> DoesPlateExist(string plateNo)
        {
            RemoveSpace(plateNo);
            Vehicle tempVehicle = _vehicleDal.Get(q => q.PlateNo == plateNo);
            return new SuccessDataResult<bool>(tempVehicle == null ? false : true);
            
            
        }

        public IDataResult<bool> PlateRuhsatCheck(string plateNo, string vehicleSerialNumberNo)
        {
            RemoveSpace(plateNo);
            var tempVehicle = _vehicleDal.Get(s => s.PlateNo == plateNo);
            return new SuccessDataResult<bool>(tempVehicle.VehicleNumberSerialNo == vehicleSerialNumberNo ? true : false);
        }

        public IDataResult<EnumGroupType> CheckVehicleTypeByPlateNo(string plateNo)
        {
            try
            {
                RemoveSpace(plateNo);
                Vehicle tempVehicle = _vehicleDal.Get(q => q.PlateNo == plateNo);
                return new SuccessDataResult<EnumGroupType>(_enumGroupTypeDal.Get(s => s.EnumGroupTypeId == tempVehicle.VehicleTypeId));
            }
            catch (Exception ex)                                                                                                                                                                                                            
            {
                return new ErrorDataResult<EnumGroupType>(message: ex.Message);                                 
            }
       }

        private void RemoveSpace(string text)
        {
            text.ToUpper();
            text.Replace(" ","");
        }
    }
}