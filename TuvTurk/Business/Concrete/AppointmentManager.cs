using System.Reflection.Metadata.Ecma335;
using TuvTurk.Business.Abstract;
using TuvTurk.Business.Constants;
using TuvTurk.DataAccess.Abstract;
using TuvTurk.Entities.Concrete;
using TuvTurk.Entities.Utilities;
using IResult = TuvTurk.Entities.Utilities.IResult;

namespace TuvTurk.Business.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IAppointmentDal _appointmentDal;
        private readonly ICustomerDal _customerDal;
        private readonly IEnumGroupTypeDal _enumGroupTypeDal;
        private readonly ICityDal _cityDal;
        private readonly IStationDal _stationdal;
        private readonly IPriceService _priceService;

        public AppointmentManager(IAppointmentDal appointmentDal, ICustomerDal customerDal, IEnumGroupTypeDal enumGroupTypeDal, ICityDal cityDal, IStationDal stationDal, IPriceService priceService)
        {
            _appointmentDal = appointmentDal;
            _customerDal = customerDal;
            _enumGroupTypeDal = enumGroupTypeDal;
            _cityDal = cityDal;
            _stationdal = stationDal;
            _priceService = priceService;
        }


        public IResult AddAppointment(Appointments appointment)
        {
            try
            {
                _appointmentDal.Add(appointment);
                return new SuccessResult(message: Messages.AppointmentAdded);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }

        public IResult DeleteAppointment(Appointments appointment)
        {
            try
            {
                _appointmentDal.Delete(appointment);
                return new SuccessResult(message: Messages.AppointmentDeleted);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }

        }

        public IDataResult<IList<Appointments>> GetAllAppointments()
        {
            try
            {
                return new SuccessDataResult<IList<Appointments>>(_appointmentDal.GetAll());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IList<Appointments>>(message: ex.Message);
            }
        }

        public IDataResult<Appointments> GetAppointmentById(long AppointmentId)
        {
            try
            {
                return new SuccessDataResult<Appointments>(_appointmentDal.Get(q => q.AppointmentID == AppointmentId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Appointments>(message: ex.Message);
            }
        }

        public IDataResult<Appointments> GetAppointmentByReservationNo(string reservationNo)
        {
            try
            {
                return new SuccessDataResult<Appointments>(_appointmentDal.Get(q => q.ReservationNo == reservationNo));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Appointments>(message: ex.Message);
            }
        }

        public IDataResult<AppointmentFieldDTO> GetAppointmentField(long appointmentId)
        {
            try
            {
                Appointments appointment = GetAppointmentById(appointmentId).Data;
                Customer customer = _customerDal.Get(c => c.ReservationNo == appointment.ReservationNo);
                string? vehicleTypeName = _enumGroupTypeDal.Get(e => e.EnumGroupTypeId == appointment.VehicleTypeId).EnumGroupTypeName;
                string? inpectionTypeName = _enumGroupTypeDal.Get(e => e.EnumGroupTypeId == appointment.InspectionTypeId).EnumGroupTypeName;
                string? cityName = _cityDal.Get(c => c.CityId == appointment.CityId).CityName;
                string? stationName = _stationdal.Get(s => s.StationId == appointment.StationId).StationName;
                double price = _priceService.GetTotalPrice(appointment.VehicleTypeId, appointment.InspectionTypeId).Data;


                AppointmentFieldDTO appointmentFieldDTO = new AppointmentFieldDTO{CustomerName = customer.CustomerName, CustomerLastName = customer.CustomerLastName, 
                                                                                    PlateNo = appointment.PlateNo, Ruhsat = appointment.VehicleNumberSerialNo, 
                                                                                    VehicleType = vehicleTypeName, InspectionType= inpectionTypeName, 
                                                                                    CityName = cityName, StationName = stationName, TotalPrice = price };

                return new SuccessDataResult<AppointmentFieldDTO>(appointmentFieldDTO);
            }   
            catch(Exception ex)
            {
                 return new ErrorDataResult<AppointmentFieldDTO>(message: ex.Message);
            }
        }

        public IResult UpdateAppointment(Appointments appointment)
        {
            try
            {
                _appointmentDal.Update(appointment);
                return new SuccessResult(message: Messages.AppointmentUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(message: ex.Message);
            }
        }
    }
}